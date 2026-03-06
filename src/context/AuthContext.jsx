import { createContext, useContext, useState } from 'react';

const AuthContext = createContext(null);

// Demo accounts
const demoAccounts = [
    {
        email: 'khach@picmate.vn',
        password: '123456',
        name: 'Nguyễn Văn Khách',
        role: 'customer',
        avatar: 'https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=100&h=100&fit=crop&crop=face',
        redirect: '/dashboard',
    },
    {
        email: 'photographer@picmate.vn',
        password: '123456',
        name: 'Đào Nguyên Trọng',
        role: 'photographer',
        avatar: 'https://scontent.fsgn7-1.fna.fbcdn.net/v/t39.30808-1/464473353_3769519109932670_1565250063960609805_n.jpg?stp=cp6_dst-jpg_s200x200_tt6&_nc_cat=105&ccb=1-7&_nc_sid=1d2534&_nc_ohc=lbRrefC4c2IQ7kNvwHmzsRn&_nc_oc=AdmL0Ye0JN88RvvXis9Sv2pnD8MeFBf_bJKGBOxzDyIMvH4czWRQTD6MejMaqLp9wt_1SRuUScRO_fvqxPlXBd0n&_nc_zt=24&_nc_ht=scontent.fsgn7-1.fna&_nc_gid=AkOnQUEZk2OubHikA_4cwA&_nc_ss=8&oh=00_AfwMb4fXvhU1mlpW5eb5jC6_-DMKrK64ex9HbGIOMXkrxw&oe=69AC0FA7',
        redirect: '/dashboard/photographer',
    },
    {
        email: 'admin@picmate.vn',
        password: 'admin123',
        name: 'Admin PICMate',
        role: 'admin',
        avatar: '',
        redirect: '/admin',
    },
];

export function AuthProvider({ children }) {
    const [user, setUser] = useState(() => {
        const saved = localStorage.getItem('picmate_user');
        return saved ? JSON.parse(saved) : null;
    });

    const login = (email, password) => {
        const account = demoAccounts.find(
            a => a.email === email && a.password === password
        );
        if (account) {
            const userData = {
                name: account.name,
                email: account.email,
                role: account.role,
                avatar: account.avatar,
                redirect: account.redirect,
            };
            setUser(userData);
            localStorage.setItem('picmate_user', JSON.stringify(userData));
            return { success: true, redirect: account.redirect };
        }
        return { success: false, message: 'Email hoặc mật khẩu không đúng!' };
    };

    const logout = () => {
        setUser(null);
        localStorage.removeItem('picmate_user');
    };

    return (
        <AuthContext.Provider value={{ user, login, logout, demoAccounts }}>
            {children}
        </AuthContext.Provider>
    );
}

export function useAuth() {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error('useAuth must be used within an AuthProvider');
    }
    return context;
}

export { demoAccounts };
