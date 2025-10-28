import { useForm } from "react-hook-form";
import type { FieldValues, SubmitHandler } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { ZodType } from "zod";
import { useState } from "react";

interface Field {
  name: string;
  label: string;
  type: string;
  placeholder?: string;
}

interface FormProps<T extends FieldValues> {
  fields: Field[];
  schema: ZodType<T>;
  onSubmit: SubmitHandler<T>;
}

export function Form<T extends FieldValues>({ fields, schema, onSubmit }: FormProps<T>) {
  const { register, handleSubmit, formState: { errors } } = useForm<T>({
    resolver: zodResolver(schema),
  });
  const [showPassword, setShowPassword] = useState(false);

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col gap-4 w-full max-w-sm sm:px-4 px-0 ">
      {fields.map(f => (
        <div key={f.name} className="max-w-2xs">
          <label className="block text-left mb-1 text-xs font-medium">{f.label}</label>
          <div className="relative">
            <input
              {...register(f.name as any)}
              type={f.type === 'password' ? (showPassword ? 'text' : 'password') : f.type}
              placeholder={f.placeholder}
              className="border p-1 rounded-sm w-full text-sm shadow-sm focus:ring-1 focus:ring-blue-500 focus:border-blue-500 outline-none"
            />
            {f.type === 'password' && (
              <button
                type="button"
                onClick={() => setShowPassword(!showPassword)}
                className="absolute right-1 top-1/2 -translate-y-1/2 text-gray-400 hover:text-gray-700 focus:outline-none focus:text-gray-700 transition-colors cursor-pointer touch-manipulation"
              >
                {showPassword ? (
                  <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-5 h-5">
                    <path strokeLinecap="round" strokeLinejoin="round" d="M3.98 8.223A10.477 10.477 0 001.934 12C3.226 16.338 7.244 19.5 12 19.5c.993 0 1.953-.138 2.863-.395M6.228 6.228A10.45 10.45 0 0112 4.5c4.756 0 8.773 3.162 10.065 7.498a10.523 10.523 0 01-4.293 5.774M6.228 6.228L3 3m3.228 3.228l3.65 3.65m7.894 7.894L21 21m-3.228-3.228l-3.65-3.65m0 0a3 3 0 10-4.243-4.243m4.242 4.242L9.88 9.88" />
                  </svg>
                ) : (
                  <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-5 h-5">
                    <path strokeLinecap="round" strokeLinejoin="round" d="M2.036 12.322a1.012 1.012 0 010-.639C3.423 7.51 7.36 4.5 12 4.5c4.638 0 8.573 3.007 9.963 7.178.07.207.07.431 0 .639C20.577 16.49 16.64 19.5 12 19.5c-4.638 0-8.573-3.007-9.963-7.178z" />
                    <path strokeLinecap="round" strokeLinejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                  </svg>
                )}
              </button>
            )}
          </div>
          {errors[f.name as keyof T] && (
            <p className="text-red-500 max-w-48 text-xs  text-left">
              {(errors[f.name as keyof T] as any)?.message}
            </p>
          )}
        </div>
      ))}
      <button
        type="submit"
        className="bg-blue-600 text-white py-3 px-4 rounded-lg w-full font-medium hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition-colors mt-2">
        Enviar
      </button>
    </form>
  );
}
