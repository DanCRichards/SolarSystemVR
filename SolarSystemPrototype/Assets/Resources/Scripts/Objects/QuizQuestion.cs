using System.Collections;
using System.Collections.Generic;


public class QuizQuestion
{

    public string question;
    public string[] answers;

    /// <summary>
    /// Constructor function for a Quiz Question.
    /// </summary>
    /// <param name="_question">String of the question: What is the square root of 4?</param>
    /// <param name="_answers">A string array of the possible answers. The first inserted answer is correct</param>
    public QuizQuestion(string _question, string[] _answers)
    {
        this.question = _question;
        this.answers = _answers;

    }

}
