import { useCallback } from 'react';
import { useReducer } from 'react';
import { createContext, useContext, useEffect } from 'react';

const CitiesContext = createContext();

const BASE_URL = `http://localhost:9000`;

const initialState = {
        cities: [],
        isLoading: false,
        currentCity: {},
        error: '',
};

function reducer(state, action) {
        switch (action.type) {
                case 'loading':
                        return { ...state, isLoading: true };

                case 'city/loaded':
                        return { ...state, isLoading: false, currentCity: action.payload };

                case 'cities/loaded':
                        return { ...state, isLoading: false, cities: action.payload };

                case 'city/created':
                        return { ...state, isLoading: false, cities: [...state.cities, action.payload], currentCity: action.payload };

                case 'cities/deleted':
                        return { ...state, isLoading: false, cities: state.cities.filter((city) => city.id !== action.payload), currentCity: {} };

                case 'rejected':
                        return { ...state, isLoading: false, error: action.payload };
                default:
                        throw new Error('Unknown action type');
        }
}

function CitiesProvider({ children }) {
        const [{ cities, isLoading, currentCity, error }, dispatch] = useReducer(reducer, initialState);

        useEffect(function () {
                async function fetchCities() {
                        dispatch({ type: 'loading' });
                        try {
                                const res = await fetch(`${BASE_URL}/cities`);
                                const data = await res.json();
                                dispatch({ type: 'cities/loaded', payload: data });
                        } catch {
                                dispatch({ type: 'rejected', payload: 'Error loading data...' });
                        }
                }

                fetchCities();
        }, []);

        const getCity = useCallback(
                async function getCity(id) {
                        //"id" is read from the URL as a string, so convert it to number, to match "currentCity.id"
                        if (Number(id) === currentCity.id) return;

                        dispatch({ type: 'loading' });
                        try {
                                const res = await fetch(`${BASE_URL}/cities/${id}`);
                                const data = await res.json();
                                dispatch({ type: 'city/loaded', payload: data });
                        } catch {
                                dispatch({ type: 'rejected', payload: 'Error fetching a city...' });
                        }
                },
                [currentCity.id]
        );

        async function createCity(newCity) {
                dispatch({ type: 'loading' });
                try {
                        const res = await fetch(`${BASE_URL}/cities`, {
                                method: 'POST',
                                body: JSON.stringify(newCity),
                                headers: {
                                        'Content-Type': 'application/json',
                                },
                        });
                        const data = await res.json();

                        dispatch({ type: 'city/created', payload: data });

                        console.log(data);
                } catch {
                        dispatch({ type: 'rejected', payload: 'Error while Creating a city...' });
                }
        }

        async function deleteCity(id) {
                dispatch({ type: 'loading' });
                try {
                        await fetch(`${BASE_URL}/cities/${id}`, {
                                method: 'DELETE',
                        });

                        dispatch({ type: 'cities/deleted', payload: id });
                } catch {
                        dispatch({ type: 'rejected', payload: 'Error while Deleting a city...' });
                }
        }

        return (
                <CitiesContext.Provider
                        value={{
                                cities,
                                isLoading,
                                currentCity,
                                error,
                                getCity,
                                createCity,
                                deleteCity,
                        }}
                >
                        {children}
                </CitiesContext.Provider>
        );
}

function useCities() {
        const x = useContext(CitiesContext);
        if (x === undefined) throw new Error('useCities was defined outside of the CitiesContext');
        return x;
}

export { useCities, CitiesProvider };
