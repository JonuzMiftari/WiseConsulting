import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Home } from "./components/Home";
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { OrderCategories } from "./components/OrderCategories";
import HomeIcon from '@mui/icons-material/Home';
import PlusOneIcon from '@mui/icons-material/PlusOne';
import WbSunnyIcon from '@mui/icons-material/WbSunny';
import CategoryIcon from '@mui/icons-material/Category';

const AppRoutes = [
    {
        index: true,
        title: 'Home',
        path: '/',
        element: <Home />,
        icon: <HomeIcon />
    },
    {
        title: 'Counter',
        path: '/counter',
        element: <Counter />,
        icon: <PlusOneIcon />
    },
    {
        title: 'Fetch weather data',
        path: '/fetch-data',
        requireAuth: false,
        element: <FetchData />,
        icon: <WbSunnyIcon />
    },
    {
        title: 'Order Categories',
        path: '/ordercategory',
        requireAuth: false,
        element: <OrderCategories />,
        icon: <CategoryIcon />
    }
    //,
    //...ApiAuthorzationRoutes
];

export default AppRoutes;
