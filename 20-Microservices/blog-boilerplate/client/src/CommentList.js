import React from 'react';

const CommentList = ({ comments }) => {
    const renderedComments = comments.map((comment) => {
        return <li key={comment.id}>{comment.status === 'pending' ? 'Comment awaiting moderation' : comment.content}</li>;
    });

    return <ul>{renderedComments}</ul>;
};

export default CommentList;
