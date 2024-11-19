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

export async function createOrEditCabin(newCabin, id) {
      const hasImagePath = newCabin.image?.startsWith?.(supabaseUrl);
      const imgName = `${Math.random()}-${newCabin.image.name}`.replace('/', '');
      // slash '/' get replaced with folers by supabase, so get rid of them
      const imgPath = hasImagePath ? newCabin.image : `${supabaseUrl}/storage/v1/object/public/cabin-images/${imgName}`;

      //1. Initial query
      let query = supabase.from('cabins');

      // 2. Create new cabin
      if (!id) query = query.insert([{ ...newCabin, image: imgPath }]);

      // 3. Edit cabin
      if (id) query = query.update({ ...newCabin, image: imgPath }).eq('id', id);

      const { data, error } = await query.select().single();

      if (error) {
            console.error(error);
            throw new Error('Cabins could not be created');
      }

      //4. Upload image if it's a new image
      if (hasImagePath) return data;

      const { error: storrageError } = await supabase.storage.from('cabin-images').upload(imgName, newCabin.image);
      //5. Delete cabin IF there was error uploading image
      if (storrageError) {
            await supabase.from('cabins').delete().eq('id', data.id);
            console.error(storrageError);
            throw new Error('Cabins image could not be uploaded and the cabin was not created.');
      }

      return data;
}
