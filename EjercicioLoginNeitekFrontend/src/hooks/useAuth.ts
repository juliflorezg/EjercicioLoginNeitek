import axios from "axios";

const API_BASE = "http://localhost:5134/api/auth";

export function useAuth() {
  const signup = async (data: any) => {
    const res = await axios.post(`${API_BASE}/signup`, data);
    return res.data;
  };

  const login = async (data: any) => {
    const res = await axios.post(`${API_BASE}/login`, data);
    return res.data;
  };

  return { signup, login };
}