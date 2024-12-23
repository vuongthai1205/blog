import React, { useState } from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';

const HeaderAdmin = ({ toggleDrawer }) => {
    return (
        <AppBar position="static">
            <div className="container">
                <Toolbar className="column">
                    <IconButton edge="start" color="inherit" aria-label="menu" onClick={toggleDrawer(true)}>
                        <MenuIcon />
                    </IconButton>
                    <Typography variant="h6">Admin Dashboard</Typography>
                </Toolbar>
            </div>
        </AppBar>
    );
};

export default HeaderAdmin;
