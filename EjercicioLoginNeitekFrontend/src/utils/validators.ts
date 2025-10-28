import { z } from "zod";

export const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

export const loginSchema = z.object({
  email: z.string().regex(emailRegex, "Formato de correo inválido"),
  password: z.string().min(1, "Se requiere contraseña"),
});

export const signupSchema = loginSchema.extend({
  userType: z.enum(["admin", "user"], { error: "Se requiere tipo de usuario" }),
  password: z.string().min(8, "La contraseña debe tener al menos 8 caracteres"),
});
