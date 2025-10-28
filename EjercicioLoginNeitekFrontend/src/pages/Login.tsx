import { Form } from "../components/Form";
import { loginSchema } from "../utils/validators";
import { useAuth } from "../hooks/useAuth";
import Logo from "../components/Logo";
import Header from "../components/Header";

export default function Login() {
  const { login } = useAuth();

  const fields = [
    { name: "email", label: "Email", type: "email" },
    { name: "password", label: "Password", type: "password" },
  ];

  return (
    <>
      <Header />
      <div className="p-0 sm:p-4 md:p-10 min-h-screen flex flex-col items-center justify-start sm:justify-center">
        <Logo />
        <div>
          <h1 className="text-xl sm:text-2xl font-semibold mb-8 text-center">Iniciar Sesión</h1>
          <Form
            fields={fields}
            schema={loginSchema}
            onSubmit={login}
          />
        </div>
      </div>
    </>
  );
}
