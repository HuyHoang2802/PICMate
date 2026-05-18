const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5274';

let bootstrap = {};
try {
  const res = await fetch(`${API_BASE_URL}/api/bootstrap`);
  if (res.ok) {
    bootstrap = await res.json();
  }
} catch {
  bootstrap = {};
}

export const photographers = bootstrap.photographers || [];
export const styles = bootstrap.styles || [];
export const services = bootstrap.services || [];
export const presets = bootstrap.presets || [];
export const bookingStatuses = bootstrap.bookingStatuses || [];
export const mockBookings = bootstrap.bookings || [];
export const testimonials = bootstrap.testimonials || [];
export const membershipPlans = bootstrap.membershipPlans || [];
export const mockUsers = bootstrap.mockUsers || [];
export const mockMessages = bootstrap.mockMessages || [];
export const mockDisputes = bootstrap.mockDisputes || [];
export const mockActivities = bootstrap.mockActivities || [];
export const favoritePhotographerIds = bootstrap.favoritePhotographerIds || [];

export const formatPrice = (price) => `${new Intl.NumberFormat('vi-VN').format(price || 0)}d`;


