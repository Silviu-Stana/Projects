import Options from './Options';

function Question({ question, dispatch, answer }) {
        //console.log(question);
        return (
                <div>
                        <h4>{question.question}</h4>
                        <Options dispatch={dispatch} question={question} answer={answer} />
                </div>
        );
}

export default Question;
