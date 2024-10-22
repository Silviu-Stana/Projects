import { useState, useEffect } from 'react';

const KEY = 'd24c5909';

export function useMovies(query) {
        const [movies, setMovies] = useState([]);
        const [isLoading, setIsLoading] = useState(false);
        const [error, setError] = useState('');

        useEffect(
                function () {
                        //callback?.(); //only call if it exists (optional chaining)

                        const controller = new AbortController();

                        async function fetchMovies() {
                                try {
                                        setIsLoading(true);
                                        setError(''); //always reset before fetching

                                        const res = await fetch(`https://www.omdbapi.com/?apikey=${KEY}&s=${query}`, {
                                                signal: controller.signal,
                                        });

                                        const data = await res.json();
                                        if (data.Response === 'False') throw new Error('Movie not found');

                                        setMovies(data.Search);
                                        setError(''); //prevent fetch cancel from writing an Error

                                        if (!res.ok) throw new Error('Something went wrong with fetching movies.');
                                } catch (err) {
                                        if (err.name !== 'AbortError') {
                                                console.log(err.message);
                                                setError(err.message);
                                        }
                                } finally {
                                        setIsLoading(false);
                                }
                        }

                        if (query.length < 4) {
                                setMovies([]);
                                setError('');
                                return;
                        }

                        //handleCloseMovie();
                        fetchMovies();

                        //On each key press, cancel current fetch request (if it hasn't finished)
                        return () => controller.abort();
                },
                [query]
        );

        return { movies, isLoading, error };
}
