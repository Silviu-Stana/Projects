import React, { Component } from 'react';
import AuthForm from './AuthForm';
import mutation from './mutations/Login';
import { graphql } from 'react-apollo';
import query from '../queries/CurrentUser';
import { hashHistory } from 'react-router';

class LoginForm extends Component {
    constructor(props) {
        super(props);

        this.state = { errors: [] };
    }

    onSubmit({ email, password }) {
        this.props.mutate({ variables: { email, password }, refetchQueries: [{ query }] }).catch((res) => {
            const errors = res.graphQLErrors.map((err) => err.message);
            this.setState({ errors });
        });
    }

    componentWillUpdate(nextProps) {
        if (!this.props.data.user && nextProps.data.user) {
            //redirect
            hashHistory.push('/dashboard');
        }
    }

    render() {
        return (
            <div>
                <h3>Login</h3>
                <AuthForm errors={this.state.errors} onSubmit={this.onSubmit.bind(this)} />
            </div>
        );
    }
}

export default graphql(query)(graphql(mutation)(LoginForm));
