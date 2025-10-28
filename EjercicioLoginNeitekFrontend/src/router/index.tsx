import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Login from "../pages/Login";
import Signup from "../pages/Signup";
import Welcome from "../pages/Welcome";

const router = createBrowserRouter([
  { path: "/", element: <Welcome /> },
  { path: "/login", element: <Login /> },
  { path: "/signup", element: <Signup /> },
]);

export const AppRouter = () => <RouterProvider router={router} />;
