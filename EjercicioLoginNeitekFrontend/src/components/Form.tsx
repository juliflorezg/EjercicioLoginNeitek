import { useForm } from "react-hook-form";
import type { FieldValues, SubmitHandler } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { ZodType } from "zod";

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

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col gap-4 w-80 mx-auto">
      {fields.map(f => (
        <div key={f.name}>
          <label className="block mb-1">{f.label}</label>
          <input
            {...register(f.name as any)}
            type={f.type}
            placeholder={f.placeholder}
            className="border p-2 rounded w-full"
          />
          {errors[f.name as keyof T] && (
            <p className="text-red-500 text-sm">
              {(errors[f.name as keyof T] as any)?.message}
            </p>
          )}
        </div>
      ))}
      <button type="submit" className="bg-blue-600 text-white py-2 rounded">
        Enviar
      </button>
    </form>
  );
}
