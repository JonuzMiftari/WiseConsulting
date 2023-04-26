import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import Dashboard from './components/Dashboard';
import './custom.css';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Routes>
                <Route element={<Dashboard />} >
                    {
                        AppRoutes.map((route, index) => {
                            const { path, element, requireAuth, ...rest } = route;
                            return <Route path={path} element={requireAuth ? <AuthorizeRoute {...rest} element={element} /> : element} key={index} />
                        })
                    }
                </Route>
            </Routes>
        )
    }
}
