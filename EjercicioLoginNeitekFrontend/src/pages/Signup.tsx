import { Form } from "../components/Form";
import { signupSchema } from "../utils/validators";
import { useAuth } from "../hooks/useAuth";
import Logo from "../components/Logo";


export default function Signup() {
  const { signup } = useAuth();

  const fields = [
    { name: "email", label: "Correo", type: "email" },
    { name: "password", label: "Contraseña", type: "password" },
    { name: "userType", label: "Tipo de Usuario", type: "text" },
  ];

  return (
    <div className="p-0 sm:p-4 md:p-10 min-h-screen sm:min-w-96 flex flex-col items-center justify-start sm:justify-center">
      <Logo />
      <div>
        <h1 className="text-2xl font-semibold mb-8 text-center">Registro</h1>
        <Form
          fields={fields}
          schema={signupSchema}
          onSubmit={signup}
        />
      </div>
    </div>
  );
}
