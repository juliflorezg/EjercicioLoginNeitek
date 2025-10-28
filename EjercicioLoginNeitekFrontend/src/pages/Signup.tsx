import { Form } from "../components/Form";
import { signupSchema } from "../utils/validators";
import { useAuth } from "../hooks/useAuth";

export default function Signup() {
  const { signup } = useAuth();

  const fields = [
    { name: "email", label: "Correo", type: "email" },
    { name: "password", label: "Contraseña", type: "password" },
    { name: "userType", label: "Tipo de Usuario", type: "text" },
  ];

  return (
    <div className="p-10">
      <h1 className="text-2xl mb-4">Registro</h1>
      <Form
        fields={fields}
        schema={signupSchema}
        onSubmit={signup}
      />
    </div>
  );
}
