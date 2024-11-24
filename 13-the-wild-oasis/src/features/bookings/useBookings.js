import { useQuery } from '@tanstack/react-query';
import { getBookings } from '../../services/apiBookings';
import { useSearchParams } from 'react-router-dom';

export function useBookings() {
      const [searchParams] = useSearchParams();

      //FILTER
      const filterValue = searchParams.get('status');
      //If the filter does not exist in url or it's "all", do nothing. Else apply filter.
      const filter = !filterValue || filterValue === 'all' ? null : { field: 'status', value: filterValue };
      // const filter = !filterValue || filterValue === 'all' ? null : { field: 'totalPrice', value: 5000, method: 'gte' };
      const sortByRaw = searchParams.get('sortBy') || 'startDate-desc';
      const [field, direction] = sortByRaw.split('-');
      const sortBy = { field, direction };

      const {
            isLoading,
            data: bookings,
            error,
      } = useQuery({
            queryKey: ['bookings', filter, sortBy], //by adding "filter" here, it allows ReactQuery to re-fetch on change
            queryFn: () => getBookings({ filter, sortBy }),
      });

      return { isLoading, bookings, error };
}
