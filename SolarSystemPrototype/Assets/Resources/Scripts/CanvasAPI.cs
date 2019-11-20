using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine;
using QuizSubmissionsNamespace;
using CourseQuizesNamespace;
using QuizSubmissionQuestionsNamespace;
using System.Text.RegularExpressions;

public class CanvasApi 
{
    private static readonly HttpClient client = new HttpClient();
    // This is super secret. 
    private static readonly string token = "Bearer 6199~udNLPgpFNfN8fUwuKZ525yUcZmgq2nsuCnb40I21YJ8vMuL1J53b1ryZayvOknT5";
	// Goodluck this API Key doesn't exist anymore :) But helps you understand what you need. 
    private static readonly int classNumber = 38864;
    private static long quizID;
    private static QuizSubmissionQuestions quizSubmissionQuestions;
    public static int questionIndex;

    // Start is called before the first frame update
    public static void Start()
    {
        getQuizDetails(); // Just gets details of the quizes available for the course
        startSubmission(); // Actually starts a submission of the quiz. NOTE: Currently starts first Quiz 
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    static void getQuizDetails()
    {
        // Note that this code will get the last quiz made in the canvas course at this current stage.

        // ======   HTTP HEADERS CREATION =======

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        client.DefaultRequestHeaders.Add("Authorization", token);


        // ======   HTTP REQUEST TO GET ALL QUIZES IN COURSE  ========
        var response = client.GetAsync("https://auckland.instructure.com:443/api/v1/courses/" + classNumber.ToString() + "/quizzes").Result;
        string responseString = "";

        // ======   CHECKING HTTP RESPONSE ====== 
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content;
            responseString = responseContent.ReadAsStringAsync().Result;
            Debug.Log(responseString);
        }
        else
        {
            // Remember that status code 200 is success. This means something went wrong D:
            Debug.LogError("getQuiz HTTP request didn't return StatusCode 200");
            Debug.Log(response.StatusCode);
            return;
        }

        // =======   CREATING QUIZ OBJECTS  ===== 
        var quizes = CourseQuizes.FromJson(responseString);


        foreach (var quiz in quizes)
        {
            quizID = quiz.Id;
            Debug.Log(quiz.Title);
        }

    }

    static void startSubmission()
    {

        // ====== GET QUIZ SUBMISSIONS ==== 

        string getQuizRequestURL = "https://auckland.instructure.com:443/api/v1/courses/" + classNumber.ToString() + "/quizzes/" + quizID.ToString() + "/submissions";
        var response = client.GetAsync(getQuizRequestURL).Result;
        var responseString = "";


        // ======   CHECKING HTTP RESPONSE ====== 
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content;
            responseString = responseContent.ReadAsStringAsync().Result;
            Debug.Log(responseString);
        }
        else
        {
            // Remember that status code 200 is success. This means something went wrong D:
            Debug.LogError("getQuiz HTTP request didn't return StatusCode 200");
            Debug.Log(response.StatusCode);
            return;
        }

        /// ===== GETTING TOKEN, SUBMISSION_ID AND ATTEMPT FROM CANVAS. 
        var quizSubmissions = QuizSubmissions.FromJson(responseString);
        long attempt = quizSubmissions.QuizSubmissionsQuizSubmissions[0].Attempt;
        string validation_token = quizSubmissions.QuizSubmissionsQuizSubmissions[0].ValidationToken;
        long submissionID = quizSubmissions.QuizSubmissionsQuizSubmissions[0].Id;
        // Note on the JSON SubmissionID is NOT ACTUALLY THE ID. Who knows what that is used for.
        // Canvas API leave it as Null. When actually "ID" is the Submission ID. 



        /// ==== GETTING QUIZ QUESTIONS / POSSIBLE ANSWERS
        getQuizRequestURL = "https://auckland.instructure.com:443/api/v1/quiz_submissions/" + submissionID.ToString() + "/questions?quiz_submission_id=" + submissionID.ToString();
        response = client.GetAsync(getQuizRequestURL).Result;
        responseString = "";


        // ======   CHECKING HTTP RESPONSE ====== 
        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content;
            responseString = responseContent.ReadAsStringAsync().Result;
            Debug.Log(responseString);
        }
        else
        {
            // Remember that status code 200 is success. This means something went wrong D:
            Debug.LogError("getQuiz HTTP request didn't return StatusCode 200");
            Debug.Log(response.StatusCode);
            return;
        }

        /// ===== SETTING UP THE QUIZ SUBMISSION QUESTION CLASS AND GETTING TEXT. 
		quizSubmissionQuestions = QuizSubmissionQuestions.FromJson(responseString);


    }

    public static string getQuestionText(int index)
    {
        questionIndex = index;
        string questionText = quizSubmissionQuestions.QuizSubmissionQuestionsQuizSubmissionQuestions[index].QuestionText;
        // Note the Question is imbedded in HTML. Using some Regex will help :)  [ I don't understand this but copy/paste].
        Match m = Regex.Match(questionText, @"<p>\s*(.+?)\s*</p>");
        questionText = m.Groups[0].Value.Remove(0, 3);
        return questionText.Substring(0, questionText.Length - 4);
    }

    public static string answer(int index)
    {
        return quizSubmissionQuestions.QuizSubmissionQuestionsQuizSubmissionQuestions[questionIndex].Answers[index].Text;
    }
}

