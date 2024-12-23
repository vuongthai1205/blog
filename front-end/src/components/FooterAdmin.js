import React from 'react';
import { Box, Typography, Container } from '@mui/material';

const FooterAdmin = () => {
    return (
        <Box
            component="footer"
            sx={{
                py: 3,
                px: 2,
                mt: 'auto',
                backgroundColor: (theme) =>
                    theme.palette.mode === 'light' ? theme.palette.grey[200] : theme.palette.grey[800],
            }}
        >
            <Container maxWidth="sm">
                <Typography variant="body1">
                    Admin Dashboard
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {'© '}
                    {new Date().getFullYear()}
                    {' Your Company Name'}
                </Typography>
            </Container>
        </Box>
    );
};

export default FooterAdmin;