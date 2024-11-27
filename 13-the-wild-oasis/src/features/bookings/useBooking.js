import { useQuery } from '@tanstack/react-query';
import { getBooking } from '../../services/apiBookings';
import { useParams } from 'react-router-dom';

export function useBooking() {
      const { bookingId } = useParams();

      const {
            isLoading,
            data: booking,
            error,
      } = useQuery({
            queryKey: ['bookings', bookingId],
            queryFn: () => getBooking(bookingId),
            retry: false, //usually it retries 3 times, but here it makes no point
      });

      return { isLoading, error, booking };
}
