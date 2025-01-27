import './style.scss';
import Paper from '@mui/material/Paper';
import FormControlLabel from '@mui/material/FormControlLabel';
import FormControl from '@mui/material/FormControl';
import {
    Button,
    Checkbox,
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    FormGroup,
    IconButton,
    InputAdornment,
    InputLabel,
    OutlinedInput,
    TextField,
    Typography,
} from '@mui/material';
import { Link } from 'react-router-dom';
import GoogleIcon from '@mui/icons-material/Google';
import FacebookIcon from '@mui/icons-material/Facebook';
import LayoutMiddle from 'layouts/LayoutMiddle';
import React, { useEffect, useState } from 'react';
import { UserRequest } from 'models/UserRequest';
import { Visibility, VisibilityOff } from '@mui/icons-material';
import { useHandleLogin } from 'hooks/useHandleLogin';
import CloseIcon from '@mui/icons-material/Close';
function LoginPage() {
    const [userRequest, setUserRequest] = useState(new UserRequest('', ''));
    const [showPassword, setShowPassword] = useState(false);
    const [open, setOpen] = useState(false);
    const handleClose = () => {
        setOpen(false);
    };
    const handleClickShowPassword = () => setShowPassword((show) => !show);
    const handleMouseDownPassword = (event) => {
        event.preventDefault();
    };

    const handleMouseUpPassword = (event) => {
        event.preventDefault();
    };

    const handleChange = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setUserRequest((values) => ({ ...values, [name]: value }));
    };

    const { isLogin, handleLogin, token } = useHandleLogin();
    useEffect(() => {
        console.log("call usee")
        if (token) {
            setOpen(true); // Mở modal khi token có giá trị
        }
    }, [token]);
    
    const submitLogin = async (e) => {
        e.preventDefault();
        await handleLogin(userRequest); // Nhận token trực tiếp
    };
    return (
        <LayoutMiddle>
            <Paper className="wrapper-form-login" elevation={3}>
                <h2 className="logo-text">
                    <Link>
                        <span>X</span>inHi
                    </Link>
                </h2>
                <h2 className="title">Sign in</h2>
                <form onSubmit={submitLogin} className="form_login">
                    <FormControl fullWidth={true} className="form-control">
                        <TextField
                            name="username"
                            onChange={handleChange}
                            id="my-input"
                            label="Username"
                            value={userRequest.username}
                            required={true}
                        />
                    </FormControl>
                    <FormControl fullWidth={true} className="form-control">
                        <InputLabel htmlFor="outlined-adornment-password">Password</InputLabel>
                        <OutlinedInput
                            required={true}
                            id="outlined-adornment-password"
                            type={showPassword ? 'text' : 'password'}
                            name="password"
                            onChange={handleChange}
                            endAdornment={
                                <InputAdornment position="end">
                                    <IconButton
                                        aria-label={showPassword ? 'hide the password' : 'display the password'}
                                        onClick={handleClickShowPassword}
                                        onMouseDown={handleMouseDownPassword}
                                        onMouseUp={handleMouseUpPassword}
                                        edge="end">
                                        {showPassword ? <VisibilityOff /> : <Visibility />}
                                    </IconButton>
                                </InputAdornment>
                            }
                            label="Password"
                        />
                    </FormControl>
                    <FormGroup>
                        <FormControlLabel control={<Checkbox />} label="Remember me" />
                    </FormGroup>
                    <Button type="submit" style={{ textTransform: 'none' }} fullWidth={true} variant="contained">
                        Login
                    </Button>
                </form>
                <Link to="/signup" className="self-center link">
                    Forgot your password?
                </Link>
                <p className="self-center text-or">or</p>
                <Button fullWidth={true} style={{ textTransform: 'none' }} variant="outlined">
                    <GoogleIcon fontSize="small" color="" className="mr-1" />
                    Sign in with Google
                </Button>
                <Button fullWidth={true} style={{ textTransform: 'none' }} variant="outlined">
                    <FacebookIcon fontSize="small" color="" className="mr-1" />
                    Sign in with Facebook
                </Button>
                <p className="seft-center text-center">
                    Don't have an account?{' '}
                    <Link className="link" to="/signup">
                        Sign up
                    </Link>
                </p>
            </Paper>
            <Dialog onClose={handleClose} aria-labelledby="customized-dialog-title" open={open}>
                <DialogTitle id="customized-dialog-title">
                    Modal title
                </DialogTitle>
                <DialogContent dividers>
                    <Typography gutterBottom>{token}</Typography>
                </DialogContent>
                <DialogActions>
                    <Button autoFocus onClick={handleClose}>
                        Save changes
                    </Button>
                </DialogActions>
            </Dialog>
        </LayoutMiddle>
    );
}

export default LoginPage;
