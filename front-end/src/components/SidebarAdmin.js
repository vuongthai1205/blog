import { Drawer, IconButton, styled, useTheme } from '@mui/material';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import Divider from '@mui/material/Divider';
import { useState } from 'react';

const drawerWidth = 240;
const DrawerHeader = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    // necessary for content to be below app bar
    ...theme.mixins.toolbar,
    justifyContent: 'flex-end',
}));
function SidebarAdmin({ open, toggleDrawer }) {
    const theme = useTheme();

    return (
        <>
            <Drawer
                open={open}
                sx={{
                    width: drawerWidth,
                    flexShrink: 0,
                    [`& .MuiDrawer-paper`]: { width: drawerWidth, boxSizing: 'border-box' },
                  }}
                onClose={toggleDrawer(false)}
                variant="persistent"
                anchor="left">
                <DrawerHeader>
                    <IconButton onClick={toggleDrawer(false)}>
                        {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
                    </IconButton>
                </DrawerHeader>
                <Divider />
                <ul>
                    <li>1312</li>
                    <li>1312</li>
                    <li>1312</li>
                    <li>1312</li>
                </ul>
            </Drawer>
        </>
    );
}

export default SidebarAdmin;
