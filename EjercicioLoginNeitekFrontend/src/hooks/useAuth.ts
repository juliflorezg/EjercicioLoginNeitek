import axios from "axios";

const API_BASE = import.meta.env.PROD ? "https://api-login-exercise-neitek.azurewebsites.net/api/auth" : "http://localhost:5134/api/auth";

interface SignupData {
  email: string;
  password: string;
  userType: string;
}

interface ApiSignupData {
  email: string;
  password: string;
  userTypeId: number;
}


const userTypeMapping: Record<string, number> = {
  'admin': 1,
  'customer': 2,
};

export function useAuth() {
  const transformSignupData = (data: SignupData): ApiSignupData => {
    return {
      email: data.email,
      password: data.password,
      userTypeId: userTypeMapping[data.userType]
    };
  };

  const signup = async (data: SignupData) => {
    const transformedData = transformSignupData(data);
    const res = await axios.post(`${API_BASE}/signup`, transformedData);
    return res.data;
  };

  const login = async (data: any) => {
    const res = await axios.post(`${API_BASE}/login`, data);
    return res.data;
  };

  return { signup, login };
}