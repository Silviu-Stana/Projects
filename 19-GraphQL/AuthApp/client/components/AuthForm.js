import React, { Component } from 'react';

class AuthForm extends Component {
    constructor(props) {
        super(props);

        this.state = { email: '', password: '' };
    }

    onSubmitForm(e) {
        e.preventDefault();

        const { email, password } = this.state;

        this.props.onSubmit({ email, password });
    }

    render() {
        return (
            <div className="row">
                <form onSubmit={this.onSubmitForm.bind(this)} className="col s6">
                    <div className="input-field">
                        <input placeholder="Email" onChange={(e) => this.setState({ email: e.target.value })} value={this.state.email} />
                    </div>
                    <div className="input-field">
                        <input type="password" placeholder="Password" onChange={(e) => this.setState({ password: e.target.value })} value={this.state.password} />
                    </div>
                    <button className="btn">Submit</button>
                </form>
            </div>
        );
    }
}

export default AuthForm;
