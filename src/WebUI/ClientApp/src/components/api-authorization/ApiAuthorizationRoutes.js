import React from 'react';
import { Login } from './Login'
import { Logout } from './Logout'
import { ApplicationPaths, LoginActions, LogoutActions } from './ApiAuthorizationConstants';
import LoginIcon from '@mui/icons-material/Login';

const ApiAuthorizationRoutes = [
    {
        title: 'Login',
        path: ApplicationPaths.Login,
        requireAuth: false,
        element: loginAction(LoginActions.Login),
        icon: <LoginIcon />
    },
    {
        title: 'Login Failed',
        path: ApplicationPaths.LoginFailed,
        requireAuth: false,
        element: loginAction(LoginActions.LoginFailed),
        icon: <LoginIcon />
    },
    {
        title: 'Login Callback',
        path: ApplicationPaths.LoginCallback,
        requireAuth: false,
        element: loginAction(LoginActions.LoginCallback),
        icon: <LoginIcon />
    },
    {
        title: 'Profile',
        path: ApplicationPaths.Profile,
        requireAuth: true,
        element: loginAction(LoginActions.Profile),
        icon: <LoginIcon />
    },
    {
        title: 'Register',
        path: ApplicationPaths.Register,
        requireAuth: false,
        element: loginAction(LoginActions.Register),
        icon: <LoginIcon />
    },
    {
        title: 'Log Out',
        path: ApplicationPaths.LogOut,
        requireAuth: true,
        element: logoutAction(LogoutActions.Logout),
        icon: <LoginIcon />
    },
    {
        title: 'LogOutCallback',
        path: ApplicationPaths.LogOutCallback,
        requireAuth: false,
        element: logoutAction(LogoutActions.LogoutCallback),
        icon: <LoginIcon />
    },
    {
        title: 'Logged Out',
        path: ApplicationPaths.LoggedOut,
        requireAuth: false,
        element: logoutAction(LogoutActions.LoggedOut),
        icon: <LoginIcon />
    }
];

function loginAction(name) {
    return <Login action={name}></Login>;
}

function logoutAction(name) {
    return <Logout action={name}></Logout>;
}

export default ApiAuthorizationRoutes;
