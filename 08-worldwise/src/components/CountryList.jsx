import { useCities } from '../contexts/CitiesContext';
import styles from './CountryList.module.css';
import Spinner from './Spinner';
import CountryItem from './CountryItem';
import Message from './Message';

function CountryList() {
        const { cities, isLoading } = useCities();
        if (isLoading) return <Spinner />;
        console.log(cities);

        const countries = cities.reduce((arr, city) => {
                //If our current list of country does not currently include the current country:
                if (!arr.map((el) => el.country).includes(city.country)) return [...arr, { country: city.country, emoji: city.emoji }];
                else return arr;
        }, []);

        if (!cities.length) return <Message message={'Add your first city by clicking on a city on the map'} />;

        return (
                <ul className={styles.countryList}>
                        {countries.map((country) => (
                                <CountryItem country={country} key={country.country} />
                        ))}
                </ul>
        );
}

export default CountryList;
