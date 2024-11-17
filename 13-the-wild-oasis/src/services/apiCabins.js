import supabase, { supabaseUrl } from './supabase';

export async function getCabins() {
      const { data, error } = await supabase.from('cabins').select('*');

      if (error) {
            console.error(error);
            throw new Error('Cabins could not be loaded');
      }

      return data;
}

export async function deleteCabin(id) {
      const { data, error } = await supabase.from('cabins').delete().eq('id', id);

      if (error) {
            console.error(error);
            throw new Error('Cabins could not be deleted');
      }

      return data;
}

export async function createCabin(newCabin) {
      //https://fyijirqbidoxyhkevtgh.supabase.co/storage/v1/object/public/cabin-images/cabin-001.jpg
      const imgName = `${Math.random()}-${newCabin.image.name}`.replace('/', '');
      // slash '/' get replaced with folers by supabase, so get rid of them
      const imgPath = `${supabaseUrl}/storage/v1/object/public/cabin-images/${imgName}`;

      //1. Create cabin
      const { data, error } = await supabase
            .from('cabins')
            .insert([{ ...newCabin, image: imgPath }])
            .select();

      if (error) {
            console.error(error);
            throw new Error('Cabins could not be created');
      }

      //2. Upload image
      const { error: storrageError } = await supabase.storage.from('cabin-images').upload(imgName, newCabin.image);
      //3. Delete cabin IF there was error uploading image
      if (storrageError) {
            await supabase.from('cabins').delete().eq('id', data.id);
            console.error(storrageError);
            throw new Error('Cabins image could not be uploaded and the cabin was not created.');
      }

      return data;
}
