import { createClient } from '@supabase/supabase-js';
export const supabaseUrl = 'https://fyijirqbidoxyhkevtgh.supabase.co';
const supabaseKey =
      'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImZ5aWppcnFiaWRveHloa2V2dGdoIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzE3NDIxMjksImV4cCI6MjA0NzMxODEyOX0.glJszMpDIMlCImFOyzOjXtFz8b16_pECQzTrx45ehf0';
const supabase = createClient(supabaseUrl, supabaseKey);

export default supabase;
