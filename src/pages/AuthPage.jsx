import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Mail, Lock, User, Camera, Eye, EyeOff, LogIn, Info } from 'lucide-react';
import { useAuth } from '../context/AuthContext';
import './AuthPage.css';

export default function AuthPage() {
    const [isLogin, setIsLogin] = useState(true);
    const [showPassword, setShowPassword] = useState(false);
    const [role, setRole] = useState('customer');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [showDemo, setShowDemo] = useState(false);

    const { login, demoAccounts } = useAuth();
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        setError('');

        if (!email || !password) {
            setError('Vui lòng nhập đầy đủ email và mật khẩu!');
            return;
        }

        const result = login(email, password);
        if (result.success) {
            navigate(result.redirect);
        } else {
            setError(result.message);
        }
    };

    const handleDemoLogin = (account) => {
        setEmail(account.email);
        setPassword(account.password);
        const result = login(account.email, account.password);
        if (result.success) {
            navigate(result.redirect);
        }
    };

    const getRoleLabel = (role) => {
        switch (role) {
            case 'customer': return '👤 Khách hàng';
            case 'photographer': return '📸 Phone-Grapher';
            case 'admin': return '🔐 Admin';
            default: return role;
        }
    };

    return (
        <div className="auth-page">
            <div className="auth-container">
                {/* Left Visual */}
                <div className="auth-visual">
                    <div className="auth-visual-content">
                        <Link to="/" className="auth-logo">
                            <Camera size={32} strokeWidth={2.5} />
                            <span>PIC<strong>Mate</strong></span>
                        </Link>
                        <h2>Biến khoảnh khắc thành nghệ thuật</h2>
                        <p>Tham gia PICMate để kết nối với hàng ngàn Phone-Grapher tài năng trên toàn quốc.</p>
                        <div className="auth-visual-stats">
                            <div className="auth-stat">
                                <strong>2,500+</strong>
                                <span>Phone-Graphers</span>
                            </div>
                            <div className="auth-stat">
                                <strong>50,000+</strong>
                                <span>Ảnh đã chụp</span>
                            </div>
                        </div>
                    </div>
                </div>

                {/* Right Form */}
                <div className="auth-form-section">
                    <div className="auth-form-wrapper">
                        <div className="auth-tabs">
                            <button
                                className={`auth-tab ${isLogin ? 'active' : ''}`}
                                onClick={() => { setIsLogin(true); setError(''); }}
                                id="auth-tab-login"
                            >
                                Đăng nhập
                            </button>
                            <button
                                className={`auth-tab ${!isLogin ? 'active' : ''}`}
                                onClick={() => { setIsLogin(false); setError(''); }}
                                id="auth-tab-register"
                            >
                                Đăng ký
                            </button>
                        </div>

                        {/* Demo Accounts Banner */}
                        <div className="demo-banner" id="demo-banner">
                            <button className="demo-banner-toggle" onClick={() => setShowDemo(!showDemo)}>
                                <Info size={16} />
                                <span>Tài khoản demo có sẵn — Nhấn để xem</span>
                            </button>
                            {showDemo && (
                                <div className="demo-accounts-list">
                                    {demoAccounts.map((acc, i) => (
                                        <button
                                            key={i}
                                            className="demo-account-btn"
                                            onClick={() => handleDemoLogin(acc)}
                                            id={`demo-login-${acc.role}`}
                                        >
                                            <div className="demo-account-info">
                                                <span className="demo-role">{getRoleLabel(acc.role)}</span>
                                                <span className="demo-email">{acc.email}</span>
                                                <span className="demo-pass">Mật khẩu: {acc.password}</span>
                                            </div>
                                            <span className="demo-login-icon">
                                                <LogIn size={16} />
                                            </span>
                                        </button>
                                    ))}
                                </div>
                            )}
                        </div>

                        <form className="auth-form" onSubmit={handleSubmit}>
                            {!isLogin && (
                                <>
                                    {/* Role Selection */}
                                    <div className="role-selection">
                                        <button
                                            type="button"
                                            className={`role-card ${role === 'customer' ? 'active' : ''}`}
                                            onClick={() => setRole('customer')}
                                            id="role-customer"
                                        >
                                            <User size={24} />
                                            <strong>Khách hàng</strong>
                                            <span>Đặt lịch chụp ảnh</span>
                                        </button>
                                        <button
                                            type="button"
                                            className={`role-card ${role === 'photographer' ? 'active' : ''}`}
                                            onClick={() => setRole('photographer')}
                                            id="role-photographer"
                                        >
                                            <Camera size={24} />
                                            <strong>Phone-Grapher</strong>
                                            <span>Nhận đơn chụp ảnh</span>
                                        </button>
                                    </div>

                                    <div className="input-group">
                                        <label>Họ và tên</label>
                                        <div className="input-icon-wrapper">
                                            <User size={18} className="input-icon" />
                                            <input type="text" className="input input-with-icon" placeholder="Nguyễn Văn A" id="auth-name" />
                                        </div>
                                    </div>
                                </>
                            )}

                            <div className="input-group">
                                <label>Email</label>
                                <div className="input-icon-wrapper">
                                    <Mail size={18} className="input-icon" />
                                    <input
                                        type="email"
                                        className="input input-with-icon"
                                        placeholder="email@example.com"
                                        value={email}
                                        onChange={(e) => { setEmail(e.target.value); setError(''); }}
                                        id="auth-email"
                                    />
                                </div>
                            </div>

                            <div className="input-group">
                                <label>Mật khẩu</label>
                                <div className="input-icon-wrapper">
                                    <Lock size={18} className="input-icon" />
                                    <input
                                        type={showPassword ? 'text' : 'password'}
                                        className="input input-with-icon"
                                        placeholder="••••••••"
                                        value={password}
                                        onChange={(e) => { setPassword(e.target.value); setError(''); }}
                                        id="auth-password"
                                    />
                                    <button type="button" className="input-toggle" onClick={() => setShowPassword(!showPassword)}>
                                        {showPassword ? <EyeOff size={18} /> : <Eye size={18} />}
                                    </button>
                                </div>
                            </div>

                            {error && (
                                <div className="auth-error" id="auth-error">
                                    ⚠️ {error}
                                </div>
                            )}

                            {isLogin && (
                                <div className="auth-extras">
                                    <label className="auth-remember">
                                        <input type="checkbox" />
                                        <span>Ghi nhớ đăng nhập</span>
                                    </label>
                                    <a href="#" className="auth-forgot">Quên mật khẩu?</a>
                                </div>
                            )}

                            <button type="submit" className="btn btn-primary btn-lg auth-submit" id="auth-submit">
                                {isLogin ? 'Đăng nhập' : 'Đăng ký'}
                            </button>

                            <div className="auth-divider">
                                <span>hoặc</span>
                            </div>

                            <button type="button" className="btn btn-ghost btn-lg auth-google" id="auth-google">
                                <svg width="20" height="20" viewBox="0 0 24 24"><path d="M22.56 12.25c0-.78-.07-1.53-.2-2.25H12v4.26h5.92a5.06 5.06 0 0 1-2.2 3.32v2.77h3.57c2.08-1.92 3.28-4.74 3.28-8.1z" fill="#4285F4" /><path d="M12 23c2.97 0 5.46-.98 7.28-2.66l-3.57-2.77c-.98.66-2.23 1.06-3.71 1.06-2.86 0-5.29-1.93-6.16-4.53H2.18v2.84C3.99 20.53 7.7 23 12 23z" fill="#34A853" /><path d="M5.84 14.09c-.22-.66-.35-1.36-.35-2.09s.13-1.43.35-2.09V7.07H2.18C1.43 8.55 1 10.22 1 12s.43 3.45 1.18 4.93l2.85-2.22.81-.62z" fill="#FBBC05" /><path d="M12 5.38c1.62 0 3.06.56 4.21 1.64l3.15-3.15C17.45 2.09 14.97 1 12 1 7.7 1 3.99 3.47 2.18 7.07l3.66 2.84c.87-2.6 3.3-4.53 6.16-4.53z" fill="#EA4335" /></svg>
                                Tiếp tục với Google
                            </button>
                        </form>

                        <p className="auth-footer-text">
                            {isLogin ? (
                                <>Chưa có tài khoản? <button onClick={() => setIsLogin(false)}>Đăng ký ngay</button></>
                            ) : (
                                <>Đã có tài khoản? <button onClick={() => setIsLogin(true)}>Đăng nhập</button></>
                            )}
                        </p>
                    </div>
                </div>
            </div>
        </div>
    );
}
