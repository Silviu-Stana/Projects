import React, { Component } from 'react';
import gql from 'graphql-tag';
import { graphql } from 'react-apollo';
import { hashHistory, Link } from 'react-router';
import fetchSongs from '../queries/fetchSongs';

class SongCreate extends Component {
      constructor(props) {
            super(props);
            this.state = { title: '' };
      }

      onSubmit(e) {
            e.preventDefault();

            this.props
                  .mutate({
                        variables: {
                              title: this.state.title,
                        },
                        refetchQueries: [{ query: fetchSongs }],
                  })
                  .then(() => {
                        hashHistory.push('/');
                  });
      }

      render() {
            return (
                  <div>
                        <Link to="/">Back</Link>
                        <h3>Create NEW song</h3>
                        <form onSubmit={this.onSubmit.bind(this)}>
                              <label>Song Title</label>
                              <input onChange={(e) => this.setState({ title: e.target.value })} value={this.state.title} />
                        </form>
                  </div>
            );
      }
}

const mutation = gql`
      mutation AddSong($title: String) {
            addSong(title: $title) {
                  title
            }
      }
`;

export default graphql(mutation)(SongCreate);
