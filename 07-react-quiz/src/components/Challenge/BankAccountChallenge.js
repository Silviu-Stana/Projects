import { useReducer } from 'react';
import './styles.css';

/*
-simple bank account functionality written using useReducer hook

-all operations can only be done if isActive is true. Else return original state

1 loan max can be owned
-negative balances not allowed. can only pay loan according to available balance
*/

function reducer(state, action) {
        let canClose = state.balance === 0 && state.loan === 0;
        if (state.isActive === false && action.type !== 'openAccount') return state;

        switch (action.type) {
                case 'openAccount':
                        return { ...state, isActive: true, balance: 500 };
                case 'deposit':
                        return { ...state, balance: state.balance + action.payload };
                case 'withdraw':
                        return { ...state, balance: state.balance >= 50 ? state.balance - action.payload : state.balance };
                case 'requestLoan':
                        if (state.loan > 0) return state;
                        return {
                                ...state,
                                loan: state.loan + action.payload,
                                balance: state.balance + action.payload,
                        };
                case 'payLoan':
                        let maxAmountThatCanBePaid = state.balance < state.loan ? state.balance : state.loan;
                        if (state.balance > 0) return { ...state, loan: state.loan - maxAmountThatCanBePaid, balance: state.balance - maxAmountThatCanBePaid };
                        else return state;
                case 'closeAccount':
                        return { ...state, isActive: canClose ? false : true };

                default:
                        throw new Error('Action unknown');
        }
}

const initialState = {
        balance: 0,
        loan: 0,
        isActive: false,
};

export default function App() {
        const [{ balance, loan, isActive }, dispatch] = useReducer(reducer, initialState);

        return (
                <div className="App">
                        <h1>useReducer Bank Account</h1>
                        <p>Balance: {balance}</p>
                        <p>Loan: {loan}</p>

                        <p>
                                <button onClick={() => dispatch({ type: 'openAccount' })} disabled={isActive}>
                                        Open account
                                </button>
                        </p>
                        <p>
                                <button onClick={() => dispatch({ type: 'deposit', payload: 150 })} disabled={!isActive}>
                                        Deposit 150
                                </button>
                        </p>
                        <p>
                                <button onClick={() => dispatch({ type: 'withdraw', payload: 50 })} disabled={!isActive}>
                                        Withdraw 50
                                </button>
                        </p>
                        <p>
                                <button onClick={() => dispatch({ type: 'requestLoan', payload: 5000 })} disabled={!isActive}>
                                        Request a loan of 5000
                                </button>
                        </p>
                        <p>
                                <button onClick={() => dispatch({ type: 'payLoan' })} disabled={!isActive}>
                                        Pay loan
                                </button>
                        </p>
                        <p>
                                <button onClick={() => dispatch({ type: 'closeAccount' })} disabled={!isActive}>
                                        Close account
                                </button>
                        </p>
                </div>
        );
}
