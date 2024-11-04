import { lazy, Suspense } from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';

import { CitiesProvider } from './contexts/CitiesContext';
import { AuthProvider } from './contexts/FakeAuthContext';
import ProtectedRoute from './pages/ProtectedRoute';

import CityList from './components/CityList';
import CountryList from './components/CountryList';
import City from './components/City';
import Form from './components/Form';
import SpinnerFullPage from './components/SpinnerFullPage';

// import Product from './pages/Product';
// import Pricing from './pages/Pricing';
// import Homepage from './pages/Homepage';
// import PageNotFound from './pages/PageNotFound';
// import AppLayout from './pages/AppLayout';
// import Login from './pages/Login';

const Homepage = lazy(() => import('./pages/Homepage'));
const Product = lazy(() => import('./pages/Product'));
const Pricing = lazy(() => import('./pages/Pricing'));
const Login = lazy(() => import('./pages/Login'));
const AppLayout = lazy(() => import('./pages/AppLayout'));
const PageNotFound = lazy(() => import('./pages/PageNotFound'));

//dist/assets/index-4b97fd3c.css   30.48 kB │ gzip:   5.09 kB
//dist/assets/index-1002f871.js   507.32 kB │ gzip: 148.14 kB

function App() {
        return (
                <div>
                        <AuthProvider>
                                <CitiesProvider>
                                        <BrowserRouter>
                                                <Suspense fallback={<SpinnerFullPage />}>
                                                        <Routes>
                                                                <Route index element={<Homepage />} />
                                                                <Route path="pricing" element={<Pricing />} />
                                                                <Route path="product" element={<Product />} />
                                                                <Route path="login" element={<Login />} />
                                                                <Route
                                                                        path="app"
                                                                        element={
                                                                                <ProtectedRoute>
                                                                                        <AppLayout />
                                                                                </ProtectedRoute>
                                                                        }
                                                                >
                                                                        <Route index element={<Navigate replace to="cities" />} />
                                                                        <Route path="cities" element={<CityList />} />
                                                                        <Route path="cities/:id" element={<City />} />
                                                                        <Route path="countries" element={<CountryList />} />
                                                                        <Route path="form" element={<Form />} />
                                                                </Route>
                                                                <Route path="*" element={<PageNotFound />} />
                                                        </Routes>
                                                </Suspense>
                                        </BrowserRouter>
                                </CitiesProvider>
                        </AuthProvider>
                </div>
        );
}

export default App;
