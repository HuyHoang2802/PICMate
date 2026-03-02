import { useState } from 'react';
import { Link } from 'react-router-dom';
import {
    User, Clock, Camera, Settings, LogOut, Star, MapPin,
    MessageCircle, Calendar, Package, CreditCard, ChevronRight
} from 'lucide-react';
import { mockBookings, bookingStatuses, formatPrice } from '../../data/data';
import './CustomerDashboard.css';

export default function CustomerDashboard() {
    const [activeTab, setActiveTab] = useState('orders');

    const getStatusBadge = (status) => {
        const s = bookingStatuses.find(b => b.key === status);
        return <span className={`badge badge-${s?.color}`}>{s?.label}</span>;
    };

    return (
        <div className="dashboard-page">
            <div className="container">
                <div className="dashboard-layout">
                    {/* Sidebar */}
                    <aside className="dashboard-sidebar">
                        <div className="dashboard-profile">
                            <img src="https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=100&h=100&fit=crop&crop=face" alt="User" className="avatar-lg" />
                            <h3>Nguyễn Văn Khách</h3>
                            <span className="badge badge-info">Khách hàng</span>
                        </div>
                        <nav className="dashboard-nav">
                            {[
                                { key: 'orders', icon: <Package size={18} />, label: 'Đơn hàng' },
                                { key: 'messages', icon: <MessageCircle size={18} />, label: 'Tin nhắn' },
                                { key: 'profile', icon: <User size={18} />, label: 'Hồ sơ' },
                                { key: 'settings', icon: <Settings size={18} />, label: 'Cài đặt' },
                            ].map(item => (
                                <button
                                    key={item.key}
                                    className={`dashboard-nav-item ${activeTab === item.key ? 'active' : ''}`}
                                    onClick={() => setActiveTab(item.key)}
                                    id={`dash-nav-${item.key}`}
                                >
                                    {item.icon} {item.label}
                                </button>
                            ))}
                            <button className="dashboard-nav-item dashboard-logout" id="dash-logout">
                                <LogOut size={18} /> Đăng xuất
                            </button>
                        </nav>
                    </aside>

                    {/* Content */}
                    <div className="dashboard-content">
                        {activeTab === 'orders' && (
                            <>
                                <div className="dashboard-content-header">
                                    <h2>Đơn hàng của tôi</h2>
                                    <Link to="/explore" className="btn btn-primary btn-sm" id="dash-new-booking">
                                        <Camera size={16} /> Đặt lịch mới
                                    </Link>
                                </div>

                                <div className="orders-list">
                                    {mockBookings.map(booking => (
                                        <div key={booking.id} className="order-card" id={`order-${booking.id}`}>
                                            <div className="order-card-header">
                                                <div className="order-photographer">
                                                    <img src={booking.photographerAvatar} alt={booking.photographerName} className="avatar" />
                                                    <div>
                                                        <strong>{booking.photographerName}</strong>
                                                        <span>{booking.service}</span>
                                                    </div>
                                                </div>
                                                {getStatusBadge(booking.status)}
                                            </div>
                                            <div className="order-card-details">
                                                <div className="order-detail">
                                                    <Calendar size={14} />
                                                    <span>{booking.date} – {booking.time}</span>
                                                </div>
                                                <div className="order-detail">
                                                    <MapPin size={14} />
                                                    <span>{booking.location}</span>
                                                </div>
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

                        {activeTab === 'messages' && (
                            <div className="dashboard-placeholder">
                                <MessageCircle size={48} />
                                <h3>Tin nhắn</h3>
                                <p>Chat 1-1 với Phone-Grapher sẽ hiển thị tại đây.</p>
                            </div>
                        )}

                        {activeTab === 'profile' && (
                            <div className="dashboard-content-header">
                                <h2>Hồ sơ cá nhân</h2>
                                <div className="profile-form">
                                    <div className="input-group"><label>Họ tên</label><input className="input" defaultValue="Nguyễn Văn Khách" /></div>
                                    <div className="input-group"><label>Email</label><input className="input" defaultValue="khach@email.com" /></div>
                                    <div className="input-group"><label>Số điện thoại</label><input className="input" defaultValue="0909 xxx xxx" /></div>
                                    <button className="btn btn-primary" id="dash-save-profile">Lưu thay đổi</button>
                                </div>
                            </div>
                        )}

                        {activeTab === 'settings' && (
                            <div className="dashboard-placeholder">
                                <Settings size={48} />
                                <h3>Cài đặt</h3>
                                <p>Quản lý thông báo, bảo mật, và tùy chọn tài khoản.</p>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
}
