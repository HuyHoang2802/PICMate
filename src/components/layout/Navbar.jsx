import { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { Menu, X, Search, Camera, User, ChevronDown } from 'lucide-react';
import './Navbar.css';

export default function Navbar() {
    const [isScrolled, setIsScrolled] = useState(false);
    const [isMobileOpen, setIsMobileOpen] = useState(false);
    const location = useLocation();

    useEffect(() => {
        const handleScroll = () => setIsScrolled(window.scrollY > 20);
        window.addEventListener('scroll', handleScroll);
        return () => window.removeEventListener('scroll', handleScroll);
    }, []);

    useEffect(() => {
        setIsMobileOpen(false);
    }, [location]);

    const navLinks = [
        { path: '/', label: 'Trang chủ' },
        { path: '/explore', label: 'Tìm thợ chụp' },
        { path: '/presets', label: 'Preset Shop' },
        { path: '/instant', label: '⚡ Chụp ngay' },
    ];

    return (
        <nav className={`navbar ${isScrolled ? 'navbar-scrolled' : ''}`} id="main-nav">
            <div className="navbar-container container">
                <Link to="/" className="navbar-logo" id="nav-logo">
                    <Camera size={28} strokeWidth={2.5} />
                    <span>PIC<strong>Mate</strong></span>
                </Link>

                <div className={`navbar-links ${isMobileOpen ? 'active' : ''}`}>
                    {navLinks.map(link => (
                        <Link
                            key={link.path}
                            to={link.path}
                            className={`navbar-link ${location.pathname === link.path ? 'active' : ''}`}
                            id={`nav-link-${link.path.replace('/', '') || 'home'}`}
                        >
                            {link.label}
                        </Link>
                    ))}

                    <div className="navbar-mobile-actions">
                        <Link to="/auth" className="btn btn-primary btn-sm" id="nav-login-mobile">
                            Đăng nhập
                        </Link>
                        <Link to="/auth?role=photographer" className="btn btn-secondary btn-sm" id="nav-register-mobile">
                            Trở thành Phone-Grapher
                        </Link>
                    </div>
                </div>

                <div className="navbar-actions">
                    <Link to="/auth" className="btn btn-ghost btn-sm" id="nav-login">
                        <User size={18} />
                        Đăng nhập
                    </Link>
                    <Link to="/auth?role=photographer" className="btn btn-primary btn-sm" id="nav-register">
                        Trở thành Phone-Grapher
                    </Link>
                </div>

                <button
                    className="navbar-toggle"
                    onClick={() => setIsMobileOpen(!isMobileOpen)}
                    aria-label="Toggle menu"
                    id="nav-toggle"
                >
                    {isMobileOpen ? <X size={24} /> : <Menu size={24} />}
                </button>
            </div>

            {isMobileOpen && <div className="navbar-overlay" onClick={() => setIsMobileOpen(false)} />}
        </nav>
    );
}
