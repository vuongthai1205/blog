import { createBrowserRouter } from 'react-router-dom';
import HomePage from '../pages/Home';
import LoginPage from '../pages/Login';
import SignupPage from '../pages/Signup';
import AdminPage from '../pages/Admin';

const router = createBrowserRouter([
    {
        path: '/',
        element: <HomePage />,
    },
    {
        path: '/login',
        element: <LoginPage />,
    },
    {
        path: '/signup',
        element: <SignupPage />,
    },
    {
        path: '/admin',
        element: <AdminPage />,
    },
]);
export { router };
