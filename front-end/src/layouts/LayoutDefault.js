import FooterComponent from '../components/Footer';
import HeaderComponent from '../components/Header';

const LayoutDefault = ({ children }) => {
    return (
        <>
            <HeaderComponent />
            <div>{children}</div>
            <FooterComponent />
        </>
    );
};

export default LayoutDefault;
