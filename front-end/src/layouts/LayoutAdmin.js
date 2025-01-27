import React, { useState } from 'react';
import FooterAdmin from '../components/FooterAdmin';
import HeaderAdmin from '../components/HeaderAdmin';
import SidebarAdmin from 'components/SidebarAdmin';
import { styled, useTheme } from '@mui/styles';
import { Box } from '@mui/material';
const drawerWidth = 240;
const Main = styled('main', { shouldForwardProp: (prop) => prop !== 'open' })(({ theme }) => ({
    flexGrow: 1,
    padding: theme.spacing(3),
    transition: theme.transitions.create('margin', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
    }),
    marginLeft: `-${drawerWidth}px`,
    variants: [
        {
            props: ({ open }) => open,
            style: {
                transition: theme.transitions.create('margin', {
                    easing: theme.transitions.easing.easeOut,
                    duration: theme.transitions.duration.enteringScreen,
                }),
                marginLeft: 0,
            },
        },
    ],
}));


const LayoutAdmin = ({ children }) => {
    const theme = useTheme();
    const [open, setOpen] = useState(false);

    const toggleDrawer = (newOpen) => () => {
        setOpen(newOpen);
    };
    return (
        <Box sx={{ display: 'flex' , flexDirection: 'column', minHeight: '100vh' }}>
            <HeaderAdmin toggleDrawer={toggleDrawer} />
            <SidebarAdmin open={open} toggleDrawer={toggleDrawer} />
            <div className="container">
                <div className="flex flex-row">
                    <div className="basis-full">{children}</div>
                </div>
            </div>
            <FooterAdmin />
        </Box>
    );
};

export default LayoutAdmin;
