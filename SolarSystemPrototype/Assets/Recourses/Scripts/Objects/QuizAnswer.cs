using System.Collections;
using System.Collections.Generic;

public class QuizAnswer{
    // Start is called before the first frame update

    public string Answer;
    public bool isCorrect;

    public QuizAnswer(string _answer, bool _isCorrect)
    {
        this.Answer = _answer;
        this.isCorrect = _isCorrect;
    }

}
