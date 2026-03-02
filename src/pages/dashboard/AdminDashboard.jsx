import { useState } from 'react';
import {
    LayoutDashboard, Users, Camera, Package, DollarSign, Shield,
    Settings, LogOut, TrendingUp, AlertTriangle, CheckCircle, XCircle,
    Eye, UserCheck, UserX, Search
} from 'lucide-react';
import { photographers, mockBookings, formatPrice } from '../../data/data';
import './AdminDashboard.css';

export default function AdminDashboard() {
    const [activeTab, setActiveTab] = useState('overview');

    const adminStats = [
        { label: 'Tổng người dùng', value: '12,450', icon: <Users size={20} />, color: 'var(--primary)', change: '+12%' },
        { label: 'Phone-Graphers', value: '2,500', icon: <Camera size={20} />, color: 'var(--accent-coral)', change: '+8%' },
        { label: 'Đơn hàng tháng', value: '3,240', icon: <Package size={20} />, color: 'var(--accent-green)', change: '+23%' },
        { label: 'Doanh thu tháng', value: '486,000,000đ', icon: <DollarSign size={20} />, color: 'var(--accent-gold)', change: '+18%' },
    ];

    const pendingPhotographers = [
        { id: 101, name: 'Trần Đình Hoàng', avatar: 'https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=100&h=100&fit=crop&crop=face', styles: ['Cá tính', 'Vintage'], portfolio: 8 },
        { id: 102, name: 'Lê Thị Mai', avatar: 'https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&h=100&fit=crop&crop=face', styles: ['Hàn Quốc', 'Minimal'], portfolio: 12 },
    ];

    return (
        <div className="dashboard-page admin-dashboard">
            <div className="container">
                <div className="dashboard-layout">
                    <aside className="dashboard-sidebar">
                        <div className="dashboard-profile">
                            <div className="admin-avatar">
                                <Shield size={24} />
                            </div>
                            <h3>Admin Panel</h3>
                            <span className="badge badge-danger">🔐 Administrator</span>
                        </div>

                        <nav className="dashboard-nav">
                            {[
                                { key: 'overview', icon: <LayoutDashboard size={18} />, label: 'Tổng quan' },
                                { key: 'users', icon: <Users size={18} />, label: 'Người dùng' },
                                { key: 'photographers', icon: <Camera size={18} />, label: 'Phone-Graphers' },
                                { key: 'orders', icon: <Package size={18} />, label: 'Đơn hàng' },
                                { key: 'disputes', icon: <AlertTriangle size={18} />, label: 'Tranh chấp' },
                                { key: 'settings', icon: <Settings size={18} />, label: 'Cài đặt' },
                            ].map(item => (
                                <button
                                    key={item.key}
                                    className={`dashboard-nav-item ${activeTab === item.key ? 'active' : ''}`}
                                    onClick={() => setActiveTab(item.key)}
                                    id={`admin-nav-${item.key}`}
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
                                <div className="dashboard-content-header"><h2>Tổng quan hệ thống</h2></div>

                                <div className="stats-grid">
                                    {adminStats.map((stat, i) => (
                                        <div key={i} className="stat-card">
                                            <div className="stat-icon" style={{ background: `${stat.color}15`, color: stat.color }}>
                                                {stat.icon}
                                            </div>
                                            <div>
                                                <span className="stat-label">{stat.label}</span>
                                                <strong className="stat-value">{stat.value}</strong>
                                                <span className="stat-change positive">{stat.change}</span>
                                            </div>
                                        </div>
                                    ))}
                                </div>

                                <div className="admin-section">
                                    <h3>⏳ Phone-Grapher chờ duyệt</h3>
                                    <div className="pending-list">
                                        {pendingPhotographers.map(p => (
                                            <div key={p.id} className="pending-card">
                                                <div className="pending-info">
                                                    <img src={p.avatar} alt={p.name} className="avatar" />
                                                    <div>
                                                        <strong>{p.name}</strong>
                                                        <span>{p.portfolio} ảnh portfolio</span>
                                                    </div>
                                                </div>
                                                <div className="pending-tags">
                                                    {p.styles.map(s => <span key={s} className="tag tag-primary">{s}</span>)}
                                                </div>
                                                <div className="pending-actions">
                                                    <button className="btn btn-primary btn-sm" id={`approve-${p.id}`}>
                                                        <CheckCircle size={14} /> Duyệt
                                                    </button>
                                                    <button className="btn btn-ghost btn-sm" id={`reject-${p.id}`}>
                                                        <XCircle size={14} /> Từ chối
                                                    </button>
                                                </div>
                                            </div>
                                        ))}
                                    </div>
                                </div>
                            </>
                        )}

                        {activeTab === 'users' && (
                            <>
                                <div className="dashboard-content-header">
                                    <h2>Quản lý người dùng</h2>
                                    <div className="admin-search">
                                        <Search size={16} />
                                        <input type="text" placeholder="Tìm user..." className="input" id="admin-search-users" />
                                    </div>
                                </div>
                                <div className="admin-table-wrapper">
                                    <table className="admin-table">
                                        <thead>
                                            <tr>
                                                <th>Tên</th>
                                                <th>Email</th>
                                                <th>Loại</th>
                                                <th>Trạng thái</th>
                                                <th>Hành động</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {[
                                                { name: 'Nguyễn Văn A', email: 'a@email.com', type: 'Khách hàng', active: true },
                                                { name: 'Minh Anh', email: 'minhanh@email.com', type: 'Phone-Grapher', active: true },
                                                { name: 'Đức Phúc', email: 'ducphuc@email.com', type: 'Phone-Grapher', active: true },
                                                { name: 'Spam User', email: 'spam@email.com', type: 'Khách hàng', active: false },
                                            ].map((u, i) => (
                                                <tr key={i}>
                                                    <td><strong>{u.name}</strong></td>
                                                    <td>{u.email}</td>
                                                    <td><span className={`badge ${u.type === 'Phone-Grapher' ? 'badge-info' : 'badge-success'}`}>{u.type}</span></td>
                                                    <td><span className={`badge ${u.active ? 'badge-success' : 'badge-danger'}`}>{u.active ? 'Hoạt động' : 'Bị khóa'}</span></td>
                                                    <td>
                                                        <button className="btn btn-ghost btn-sm">{u.active ? 'Khóa' : 'Mở khóa'}</button>
                                                    </td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </table>
                                </div>
                            </>
                        )}

                        {activeTab === 'photographers' && (
                            <div className="dashboard-placeholder">
                                <Camera size={48} />
                                <h3>Quản lý Phone-Graphers</h3>
                                <p>Duyệt, xác thực CCCD, quản lý portfolio và hoạt động.</p>
                            </div>
                        )}

                        {activeTab === 'orders' && (
                            <div className="dashboard-placeholder">
                                <Package size={48} />
                                <h3>Quản lý đơn hàng</h3>
                                <p>Theo dõi tất cả đơn hàng, xử lý hoàn tiền và tranh chấp.</p>
                            </div>
                        )}

                        {activeTab === 'disputes' && (
                            <div className="dashboard-placeholder">
                                <AlertTriangle size={48} />
                                <h3>Xử lý tranh chấp</h3>
                                <p>Khiếu nại, report, giữ tiền khi có tranh chấp giữa khách và thợ.</p>
                            </div>
                        )}

                        {activeTab === 'settings' && (
                            <div className="dashboard-placeholder">
                                <Settings size={48} />
                                <h3>Cài đặt hệ thống</h3>
                                <p>Phí platform, cấu hình thanh toán, thông báo.</p>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
}
