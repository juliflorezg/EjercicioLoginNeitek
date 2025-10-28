import { Link, useLocation } from "react-router-dom";

export default function Header() {
  const location = useLocation();

  return (
    <header className="flex justify-between items-center p-4 bg-blue-600 text-white shadow">
      <h1 className="text-xl font-semibold">
        <Link to="/" className="hover:text-gray-200 transition">
          Inicio
        </Link>
      </h1>

      <nav className="flex gap-4">
        {location.pathname !== "/login" && (
          <Link to="/login" className="hover:underline">
            Iniciar Sesión
          </Link>
        )}
        {location.pathname !== "/signup" && (
          <Link to="/signup" className="hover:underline">
            Registro
          </Link>
        )}
      </nav>
    </header>
  );
}
