import React, { useState } from 'react';
import FooterAdmin from '../components/FooterAdmin';
import HeaderAdmin from '../components/HeaderAdmin';
import SidebarAdmin from 'components/SidebarAdmin';

const LayoutAdmin = ({ children }) => {
    const [open, setOpen] = useState(false);

    const toggleDrawer = (newOpen) => () => {
        setOpen(newOpen);
    };
    return (
        <div className="admin-layout">
            <HeaderAdmin toggleDrawer={toggleDrawer}/>
            <div className="container">
                <div className="flex flex-row">
                    <div className="lg:basis-3/12 basis-3/12">
                        <SidebarAdmin open={open} toggleDrawer={toggleDrawer}/>
                    </div>
                    <div className="basis-full">{children}</div>
                </div>
            </div>
            <FooterAdmin />
        </div>
    );
};

export default LayoutAdmin;
