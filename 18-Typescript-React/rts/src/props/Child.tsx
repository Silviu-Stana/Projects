import React from 'react';

interface ChildProps {
      color: string;
}

export const Child = ({ color }: ChildProps) => {
      return <h1>{color}</h1>;
};
