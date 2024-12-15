'use server';

import { revalidatePath } from 'next/cache';
import { auth, signIn, signOut } from './auth';
import { supabase } from './supabase';
import { getBookings } from './data-service';
import { redirect } from 'next/navigation';

export async function updateGuest(formData) {
      console.log(formData);
      const session = await auth();
      if (!session) throw new Error('You must be logged in');

      const nationalID = formData.get('nationalID');
      const [nationality, countryFlag] = formData.get('nationality').split('%');

      if (!/^[a-zA-Z0-9]{6,12}$/.test(nationalID)) throw new Error('Please provide a valid national ID');

      const updateData = { nationality, countryFlag, nationalID };

      const { data, error } = await supabase.from('guests').update(updateData).eq('id', session.user.guestId);

      if (error) throw new Error('Guest could not be updated');

      revalidatePath('/account/profile');
}

export async function deleteReservation(bookingId) {
      const session = await auth();
      if (!session) throw new Error('You must be logged in');

      const guestBookings = await getBookings(session.user.guestId);
      const guestBookingIds = guestBookings.map((booking) => booking.id);

      if (!guestBookingIds.includes(bookingId)) throw new Error('You are not allowed to delete this booking.');

      const { error } = await supabase.from('bookings').delete().eq('id', bookingId);
      if (error) throw new Error('Booking could not be deleted');

      revalidatePath('/account/reservations');
}

export async function editReservation(formData) {
      const bookingId = formData.get('reservationId');
      const numGuests = formData.get('numGuests');
      const observations = formData.get('observations');

      const session = await auth();
      if (!session) throw new Error('You must be logged in');

      //What are all the bookings of the logged in user?
      //He should only be allowed to edit his own bookings.
      const guestBookings = await getBookings(session.user.guestId);
      const guestBookingIds = guestBookings.map((booking) => booking.id);
      //console.log(guestBookingIds);

      if (!guestBookingIds.includes(Number(bookingId))) throw new Error('You are not allowed to edit this booking.');

      const { error } = await supabase.from('bookings').update({ numGuests, observations }).eq('id', bookingId);
      if (error) throw new Error('Reservation could not be updated.');

      revalidatePath('/account/reservations');
      redirect('/account/reservations');
}

export async function signInAction() {
      await signIn('google', { redirectTo: '/account' });
}

export async function signOutAction() {
      await signOut({ redirectTo: '/' });
}