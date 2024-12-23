import 'styles/style.scss';
import { router } from 'routes';
import { RouterProvider } from 'react-router-dom';
import { useCookies } from 'react-cookie';

function App() {
    return <RouterProvider router={router} />;
}

export default App;
