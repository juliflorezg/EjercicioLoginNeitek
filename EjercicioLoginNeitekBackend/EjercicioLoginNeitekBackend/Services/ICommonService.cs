namespace EjercicioLoginNeitekBackend.Services
{
    public interface ICommonService<T, TI, TU>
    {
        public List<string> Errors { get; }
        Task<IEnumerable<T>> Get();
        Task<T?> GetById(int id);

        Task<T> Add(TI skateInsertDto);
        Task<T> Update(int id, TU skateUpdateDto);
        Task<T> Delete(int id);

        bool Validate(TI insertDto);
        bool Validate(TU updateDto);
    }
}
