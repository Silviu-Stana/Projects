//all routes that start with /api/auth/[ANYTHING]
//will be handled by "auth.js"
//that's what [...nextauth] means

export { GET, POST } from '@/app/_lib/auth';
