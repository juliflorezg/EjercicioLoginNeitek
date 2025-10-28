import Header from "../components/Header";
import { Link } from "react-router-dom";

export default function Welcome() {
  return (
    <div className="flex flex-col min-h-screen">
      <Header />

      <main className="flex flex-col items-center justify-center flex-1 text-center p-10">
        <h2 className="text-3xl font-semibold mb-4">Bienvenid@ 👋</h2>
        <p className="text-gray-600 mb-6">
          Regístrate para crear una cuenta o inicia sesión si ya tienes una.
        </p>

        <div className="flex gap-4">
          <Link
            to="/signup"
            className="bg-blue-600 text-white px-5 py-2 rounded hover:bg-blue-700 transition"
          >
            Registro
          </Link>
          <Link
            to="/login"
            className="border border-blue-600 text-blue-600 px-5 py-2 rounded hover:bg-blue-600 hover:text-white transition"
          >
            Iniciar Sesión
          </Link>
        </div>
      </main>
    </div>
  );
}
