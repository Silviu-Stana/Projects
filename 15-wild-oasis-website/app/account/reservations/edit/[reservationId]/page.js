import EditReservationButton from '@/app/_components/EditReservationButton';
import { editReservation } from '@/app/_lib/actions';
import { getBooking, getCabin } from '@/app/_lib/data-service';

export default async function Page({ params }) {
      const reservationId = params.reservationId;

      const reservation = await getBooking(reservationId);
      const { numGuests, observations } = reservation;

      const cabin = await getCabin(reservation.cabinId);
      const { maxCapacity } = cabin;

      // console.log(reservation);
      // console.log(cabin);

      return (
            <div>
                  <h2 className="font-semibold text-2xl text-accent-400 mb-7">Edit Reservation #{reservationId}</h2>

                  <form action={editReservation} className="bg-primary-900 py-8 px-12 text-lg flex gap-6 flex-col">
                        <div className="space-y-2">
                              <label htmlFor="numGuests">How many guests?</label>
                              <select defaultValue={numGuests} name="numGuests" id="numGuests" className="px-5 py-3 bg-primary-200 text-primary-800 w-full shadow-sm rounded-sm" required>
                                    <option value="" key="">
                                          Select number of guests...
                                    </option>
                                    {Array.from({ length: maxCapacity }, (_, i) => i + 1).map((x) => (
                                          <option value={x} key={x}>
                                                {x} {x === 1 ? 'guest' : 'guests'}
                                          </option>
                                    ))}
                              </select>
                        </div>

                        <div className="space-y-2">
                              <label htmlFor="observations">Anything we should know about your stay?</label>
                              <textarea defaultValue={observations} name="observations" className="px-5 py-3 bg-primary-200 text-primary-800 w-full shadow-sm rounded-sm" />
                        </div>

                        <input type="hidden" value={reservationId} name="reservationId"></input>

                        <div className="flex justify-end items-center gap-6">
                              <EditReservationButton />
                        </div>
                  </form>
            </div>
      );
}
