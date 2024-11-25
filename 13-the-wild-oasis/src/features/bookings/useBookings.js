import { useQuery, useQueryClient } from '@tanstack/react-query';
import { getBookings } from '../../services/apiBookings';
import { useSearchParams } from 'react-router-dom';

export function useBookings() {
      const [searchParams] = useSearchParams();
      const queryClient = useQueryClient();

      //FILTER
      const filterValue = searchParams.get('status');
      //If the filter does not exist in url or it's "all", do nothing. Else apply filter.
      const filter = !filterValue || filterValue === 'all' ? null : { field: 'status', value: filterValue };
      // const filter = !filterValue || filterValue === 'all' ? null : { field: 'totalPrice', value: 5000, method: 'gte' };

      //SORT
      const sortByRaw = searchParams.get('sortBy') || 'startDate-desc';
      const [field, direction] = sortByRaw.split('-');
      const sortBy = { field, direction };

      //PAGINATION
      const page = !searchParams.get('page') ? 1 : Number(searchParams.get('page'));
      const {
            isLoading,
            data: { data: bookings, count } = {}, //empty array because initially the data does not exist
            error,
      } = useQuery({
            queryKey: ['bookings', filter, sortBy, page], //by adding "filter" here, it allows ReactQuery to re-fetch on change
            queryFn: () => getBookings({ filter, sortBy, page }),
      });

      //PRE-FETCH
      const pageCount = Math.ceil(count / 10);

      if (page < pageCount)
            queryClient.prefetchQuery({
                  queryKey: ['bookings', filter, sortBy, page + 1],
                  queryFn: () => getBookings({ filter, sortBy, page: page + 1 }),
            });

      if (page > 1)
            queryClient.prefetchQuery({
                  queryKey: ['bookings', filter, sortBy, page - 1],
                  queryFn: () => getBookings({ filter, sortBy, page: page - 1 }),
            });

      return { isLoading, bookings, error, count };
}
