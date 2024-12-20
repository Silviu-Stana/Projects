import { useEffect, useState } from 'react';
import StarRating from './StarRating';

const tempMovieData = [
        {
                imdbID: 'tt1375666',
                Title: 'Inception',
                Year: '2010',
                Poster: 'https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg',
        },
        {
                imdbID: 'tt0133093',
                Title: 'The Matrix',
                Year: '1999',
                Poster: 'https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SX300.jpg',
        },
        {
                imdbID: 'tt6751668',
                Title: 'Parasite',
                Year: '2019',
                Poster: 'https://m.media-amazon.com/images/M/MV5BYWZjMjk3ZTItODQ2ZC00NTY5LWE0ZDYtZTI3MjcwN2Q5NTVkXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_SX300.jpg',
        },
];

const tempWatchedData = [
        {
                imdbID: 'tt1375666',
                Title: 'Inception',
                Year: '2010',
                Poster: 'https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SX300.jpg',
                runtime: 148,
                imdbRating: 8.8,
                userRating: 10,
        },
        {
                imdbID: 'tt0088763',
                Title: 'Back to the Future',
                Year: '1985',
                Poster: 'https://m.media-amazon.com/images/M/MV5BZmU0M2Y1OGUtZjIxNi00ZjBkLTg1MjgtOWIyNThiZWIwYjRiXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg',
                runtime: 116,
                imdbRating: 8.5,
                userRating: 9,
        },
];

const average = (arr) => arr.reduce((acc, cur, i, arr) => acc + cur / arr.length, 0);
const KEY = 'd24c5909';

export default function App() {
        const [query, setQuery] = useState('');
        const [movies, setMovies] = useState([]);
        const [watched, setWatched] = useState([]);
        const [isLoading, setIsLoading] = useState(false);
        const [error, setError] = useState('');
        const [selectedId, setSelectedId] = useState(null);
        let rating = 0;
        //inception

        /*  useEffect(function () {console.log('A');}, []);
        useEffect(function () {console.log('B');});
        console.log('C');  */

        function handleSelectMovie(id) {
                setSelectedId((selectedId) => (selectedId === id ? null : id));
        }
        function handleCloseMovie() {
                setSelectedId(null);
        }

        function handleAddWatched(movie) {
                setWatched((watched) => [...watched, movie]);
        }

        function handleDeleteWatched(id) {
                setWatched((watched) => watched.filter((movie) => movie.imdbID !== id));
        }

        useEffect(
                function () {
                        const controller = new AbortController();

                        async function fetchMovies() {
                                try {
                                        setIsLoading(true);
                                        setError(''); //always reset before fetching

                                        const res = await fetch(`https://www.omdbapi.com/?apikey=${KEY}&s=${query}`, { signal: controller.signal });

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

                        fetchMovies();

                        //On each key press, cancel current fetch request (if it hasn't finished)
                        return () => controller.abort();
                },
                [query]
        );

        return (
                <>
                        <NavigationBar>
                                <SearchBar query={query} setQuery={setQuery} />
                                <NumberOfResults movies={movies} />
                        </NavigationBar>
                        <Main>
                                <Box>
                                        {/* {isLoading ? <Loader /> : <MoviesList movies={movies} />} */}
                                        {isLoading && <Loader />}
                                        {!isLoading && !error && <MoviesList movies={movies} onSelectMovie={handleSelectMovie} />}
                                        {error && <ErrorMessage message={error} />}
                                </Box>
                                <Box>
                                        {selectedId ? (
                                                <MovieDetails
                                                        selectedId={selectedId}
                                                        onCloseMovie={handleCloseMovie}
                                                        onAddWatched={handleAddWatched}
                                                        watched={watched}
                                                />
                                        ) : (
                                                <>
                                                        <WatchedMovieSummary watched={watched} />
                                                        <WatchedMovieList watched={watched} onDeleteMovie={handleDeleteWatched} />
                                                </>
                                        )}
                                </Box>
                        </Main>
                </>
        );
}

function Main({ children }) {
        return <main className="main">{children}</main>;
}

function Loader() {
        return <p className="loader">Loading...</p>;
}

function ErrorMessage({ message }) {
        return (
                <p className="error">
                        <span>⛔</span>
                        {message}
                </p>
        );
}

function NavigationBar({ children }) {
        return (
                <nav className="nav-bar">
                        <Logo />
                        {children}
                </nav>
        );
}

function NumberOfResults({ movies }) {
        return (
                <p className="num-results">
                        Found <strong>{movies.length}</strong> results
                </p>
        );
}

function Logo() {
        return (
                <div className="logo">
                        <span role="img">🍿</span>
                        <h1>usePopcorn</h1>
                </div>
        );
}

function SearchBar({ query, setQuery }) {
        return <input className="search" type="text" placeholder="Search movies..." value={query} onChange={(e) => setQuery(e.target.value)} />;
}

function WatchedMovieSummary({ watched }) {
        const avgImdbRating = average(watched.map((movie) => movie.imdbRating));
        const avgUserRating = average(watched.map((movie) => movie.userRating));
        const avgRuntime = average(watched.map((movie) => movie.runtime));

        return (
                <div className="summary">
                        <h2>Movies you watched</h2>
                        <div>
                                <p>
                                        <span>#️⃣</span>
                                        <span>{watched.length} movies</span>
                                </p>
                                <p>
                                        <span>⭐️</span>
                                        <span>{avgImdbRating.toFixed(2)}</span>
                                </p>
                                <p>
                                        <span>🌟</span>
                                        <span>{avgUserRating.toFixed(2)}</span>
                                </p>
                                <p>
                                        <span>⏳</span>
                                        <span>{avgRuntime} min</span>
                                </p>
                        </div>
                </div>
        );
}

function MovieDetails({ selectedId, onCloseMovie, onAddWatched, watched }) {
        const [movie, setMovie] = useState({});
        const [isLoading, setIsLoading] = useState(false);
        const [userRating, setUserRating] = useState('');

        const isWatched = watched.map((movie) => movie.imdbID).includes(selectedId);
        //using ?. operator in case there is no existing rating, which would make "userRating" undefined
        const existingUserRating = watched.find((movie) => movie.imdbID === selectedId)?.userRating;

        const {
                Title: title,
                Year: year,
                Poster: poster,
                Runtime: runtime,
                imdbRating,
                Plot: plot,
                Released: released,
                Actors: actors,
                Director: director,
                Genre: genre,
        } = movie;

        function handleAdd() {
                const newWatchedMovie = {
                        imdbID: selectedId,
                        title,
                        year,
                        poster,
                        imdbRating: Number(imdbRating),
                        userRating,
                        runtime: Number(runtime.split(' ').at(0)),
                };

                onAddWatched(newWatchedMovie);
                onCloseMovie();
        }

        useEffect(
                function () {
                        function callback(e) {
                                if (e.code === 'Escape') {
                                        onCloseMovie();
                                        //console.log('CLOSING')
                                }
                        }

                        document.addEventListener('keydown', callback);

                        //Make sure you delete that event listener, otherwise they keep stacking (being added)
                        return () => document.removeEventListener('keydown', callback);
                },
                [onCloseMovie]
        );

        useEffect(
                function () {
                        async function getMovieDetails() {
                                setIsLoading(true);
                                const res = await fetch(`https://www.omdbapi.com/?apikey=${KEY}&i=${selectedId}`);
                                const data = await res.json();
                                //console.log(data);
                                setMovie(data);
                                setIsLoading(false);
                        }
                        getMovieDetails();
                },
                [selectedId]
        );

        useEffect(
                function () {
                        if (!title) return;
                        document.title = `Movie | ${title}`;
                        //async function changePageTitle() {}
                        //changePageTitle();

                        return function () {
                                document.title = 'usePopcorn';
                                //console.log(`Clean up effect for movie ${title}`)
                        };
                },
                [title]
        );

        if (isLoading) return <Loader />;
        else
                return (
                        <div className="details">
                                <header>
                                        <button className="btn-back" onClick={onCloseMovie}>
                                                &larr;
                                        </button>
                                        <img src={poster} alt={`Poster of ${movie} movie`} />
                                        <div className="details-overview">
                                                <h2>{title}</h2>
                                                <p>
                                                        {released} &bull; {runtime}
                                                </p>
                                                <p>{genre}</p>
                                                <p>
                                                        <span>⭐</span>
                                                        {imdbRating} IMDb rating
                                                </p>
                                        </div>
                                </header>

                                <section>
                                        <div className="rating">
                                                {!isWatched ? (
                                                        <>
                                                                <StarRating maxRating={10} size="24" onSetRating={setUserRating} />

                                                                {userRating > 0 && (
                                                                        <button className="btn-add" onClick={handleAdd}>
                                                                                + Add to list
                                                                        </button>
                                                                )}
                                                        </>
                                                ) : (
                                                        <p>
                                                                You rated this movie <span>⭐</span>
                                                                {existingUserRating}
                                                        </p>
                                                )}
                                        </div>

                                        <p>
                                                <em>{plot}</em>
                                        </p>
                                        <p>Starring {actors}</p>
                                        <p>Directed by {director}</p>
                                </section>
                        </div>
                );
}

function WatchedMovieList({ watched, onDeleteMovie }) {
        return (
                <ul className="list">
                        {watched.map((movie) => (
                                <WatchedMovie movie={movie} key={movie.imdbID} onDeleteMovie={onDeleteMovie} />
                        ))}
                </ul>
        );
}

function WatchedMovie({ movie, onDeleteMovie }) {
        return (
                <li>
                        <img src={movie.poster} alt={`${movie.title} poster`} />
                        <h3>{movie.title}</h3>
                        <div>
                                <p>
                                        <span>⭐️</span>
                                        <span>{movie.imdbRating}</span>
                                </p>
                                <p>
                                        <span>🌟</span>
                                        <span>{movie.userRating ? movie.userRating : '0'}</span>
                                </p>
                                <p>
                                        <span>⏳</span>
                                        <span>{movie.runtime} min</span>
                                        <button className="btn-delete" onClick={() => onDeleteMovie(movie.imdbID)}>
                                                X
                                        </button>
                                </p>
                        </div>
                </li>
        );
}

/*
function WatchedBox() {
        const [watched, setWatched] = useState(tempWatchedData);
        const [isOpen2, setIsOpen2] = useState(true);

        return (
                <div className="box">
                        <button className="btn-toggle" onClick={() => setIsOpen2((open) => !open)}>
                                {isOpen2 ? '–' : '+'}
                        </button>
                        {isOpen2 && (
                                <>
                                        <WatchedMovieSummary watched={watched} />

                                        <WatchedMovieList watched={watched} />
                                </>
                        )}
                </div>
        );
}
*/

function Box({ children }) {
        const [isOpen, setIsOpen] = useState(true);

        return (
                <div className="box">
                        <button className="btn-toggle" onRate={() => setIsOpen((open) => !open)}>
                                {isOpen ? '–' : '+'}
                        </button>

                        {isOpen && children}
                </div>
        );
}

function MoviesList({ movies, onSelectMovie }) {
        return (
                <ul className="list list-movies">
                        {movies?.map((movie) => (
                                <Movie movie={movie} key={movie.imdbID} onSelectMovie={onSelectMovie} />
                        ))}
                </ul>
        );
}

function Movie({ movie, onSelectMovie }) {
        return (
                <li onClick={() => onSelectMovie(movie.imdbID)}>
                        <img src={movie.Poster} alt={`${movie.Title} poster`} />
                        <h3>{movie.Title}</h3>
                        <div>
                                <p>
                                        <span>🗓</span>
                                        <span>{movie.Year}</span>
                                </p>
                        </div>
                </li>
        );
}
