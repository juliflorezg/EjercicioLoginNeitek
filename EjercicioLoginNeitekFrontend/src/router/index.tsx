import { createBrowserRouter, RouterProvider } from "react-router-dom";
// import Login from "../pages/Login";
import Signup from "../pages/Signup";

const router = createBrowserRouter([
  // { path: "/login", element: <Login /> },
  { path: "/signup", element: <Signup /> },
]);

export const AppRouter = () => <RouterProvider router={router} />;
