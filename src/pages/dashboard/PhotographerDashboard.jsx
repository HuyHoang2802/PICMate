import { useState } from 'react';
import {
    Camera, DollarSign, TrendingUp, Clock, Package, Users, Settings, LogOut,
    Eye, ToggleLeft, ToggleRight, Star, MapPin, Calendar, CheckCircle, Zap, Image
} from 'lucide-react';
import { mockBookings, bookingStatuses, formatPrice } from '../../data/data';
import './PhotographerDashboard.css';

export default function PhotographerDashboard() {
    const [activeTab, setActiveTab] = useState('overview');
    const [isOnline, setIsOnline] = useState(true);

    const getStatusBadge = (status) => {
        const s = bookingStatuses.find(b => b.key === status);
        return <span className={`badge badge-${s?.color}`}>{s?.label}</span>;
    };

    const stats = [
        { label: 'Doanh thu tháng', value: '3,200,000đ', icon: <DollarSign size={20} />, color: 'var(--accent-green)' },
        { label: 'Đơn hoàn thành', value: '24', icon: <CheckCircle size={20} />, color: 'var(--primary)' },
        { label: 'Đánh giá TB', value: '4.9 ⭐', icon: <Star size={20} />, color: 'var(--accent-gold)' },
        { label: 'Lượt xem hồ sơ', value: '1,245', icon: <Eye size={20} />, color: 'var(--accent-coral)' },
    ];

    return (
        <div className="dashboard-page">
            <div className="container">
                <div className="dashboard-layout">
                    <aside className="dashboard-sidebar">
                        <div className="dashboard-profile">
                            <img src="https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&h=100&fit=crop&crop=face" alt="Photographer" className="avatar-lg" />
                            <h3>Minh Anh</h3>
                            <span className="badge badge-info">📸 Phone-Grapher</span>
                        </div>

                        <div className="online-toggle" id="online-toggle">
                            <button className={`online-btn ${isOnline ? 'active' : ''}`} onClick={() => setIsOnline(!isOnline)}>
                                {isOnline ? <ToggleRight size={24} /> : <ToggleLeft size={24} />}
                                <span>{isOnline ? 'Đang Online' : 'Offline'}</span>
                            </button>
                        </div>

                        <nav className="dashboard-nav">
                            {[
                                { key: 'overview', icon: <TrendingUp size={18} />, label: 'Tổng quan' },
                                { key: 'orders', icon: <Package size={18} />, label: 'Đơn hàng' },
                                { key: 'portfolio', icon: <Image size={18} />, label: 'Portfolio' },
                                { key: 'settings', icon: <Settings size={18} />, label: 'Cài đặt' },
                            ].map(item => (
                                <button
                                    key={item.key}
                                    className={`dashboard-nav-item ${activeTab === item.key ? 'active' : ''}`}
                                    onClick={() => setActiveTab(item.key)}
                                    id={`pg-nav-${item.key}`}
                                >
                                    {item.icon} {item.label}
                                </button>
                            ))}
                            <button className="dashboard-nav-item dashboard-logout"><LogOut size={18} /> Đăng xuất</button>
                        </nav>
                    </aside>

                    <div className="dashboard-content">
                        {activeTab === 'overview' && (
                            <>
                                <div className="dashboard-content-header">
                                    <h2>Tổng quan</h2>
                                </div>

                                <div className="stats-grid">
                                    {stats.map((stat, i) => (
                                        <div key={i} className="stat-card">
                                            <div className="stat-icon" style={{ background: `${stat.color}15`, color: stat.color }}>
                                                {stat.icon}
                                            </div>
                                            <div>
                                                <span className="stat-label">{stat.label}</span>
                                                <strong className="stat-value">{stat.value}</strong>
                                            </div>
                                        </div>
                                    ))}
                                </div>

                                <div className="chart-placeholder">
                                    <TrendingUp size={40} />
                                    <h3>Biểu đồ doanh thu</h3>
                                    <p>Doanh thu 30 ngày qua sẽ hiển thị tại đây.</p>
                                    <div className="chart-bars">
                                        {[40, 65, 45, 80, 55, 90, 70, 85, 60, 95, 75, 88].map((h, i) => (
                                            <div key={i} className="chart-bar" style={{ height: `${h}%` }} />
                                        ))}
                                    </div>
                                </div>

                                <h3 style={{ marginTop: 'var(--space-xl)', marginBottom: 'var(--space-md)' }}>Đơn hàng gần đây</h3>
                                <div className="orders-list">
                                    {mockBookings.slice(0, 2).map(booking => (
                                        <div key={booking.id} className="order-card">
                                            <div className="order-card-header">
                                                <div className="order-photographer">
                                                    <div>
                                                        <strong>Khách: {booking.photographerName}</strong>
                                                        <span>{booking.service}</span>
                                                    </div>
                                                </div>
                                                {getStatusBadge(booking.status)}
                                            </div>
                                            <div className="order-card-details">
                                                <div className="order-detail"><Calendar size={14} /><span>{booking.date} – {booking.time}</span></div>
                                                <div className="order-detail"><MapPin size={14} /><span>{booking.location}</span></div>
                                            </div>
                                            <div className="order-card-footer">
                                                <span className="order-id">{booking.id}</span>
                                                <strong className="order-total">{formatPrice(booking.total)}</strong>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            </>
                        )}

                        {activeTab === 'orders' && (
                            <>
                                <div className="dashboard-content-header"><h2>Đơn hàng</h2></div>
                                <div className="orders-list">
                                    {mockBookings.map(b => (
                                        <div key={b.id} className="order-card">
                                            <div className="order-card-header">
                                                <div className="order-photographer">
                                                    <div><strong>{b.service}</strong><span>{b.note}</span></div>
                                                </div>
                                                {getStatusBadge(b.status)}
                                            </div>
                                            <div className="order-card-details">
                                                <div className="order-detail"><Calendar size={14} /><span>{b.date} – {b.time}</span></div>
                                                <div className="order-detail"><MapPin size={14} /><span>{b.location}</span></div>
                                            </div>
                                            <div className="order-card-footer">
                                                <span className="order-id">{b.id}</span>
                                                <strong className="order-total">{formatPrice(b.total)}</strong>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            </>
                        )}

                        {activeTab === 'portfolio' && (
                            <div className="dashboard-placeholder">
                                <Image size={48} />
                                <h3>Quản lý Portfolio</h3>
                                <p>Thêm, xóa, sắp xếp ảnh portfolio của bạn.</p>
                            </div>
                        )}

                        {activeTab === 'settings' && (
                            <div className="dashboard-placeholder">
                                <Settings size={48} />
                                <h3>Cài đặt</h3>
                                <p>Cập nhật giá, khu vực hoạt động, và thông tin cá nhân.</p>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
}
