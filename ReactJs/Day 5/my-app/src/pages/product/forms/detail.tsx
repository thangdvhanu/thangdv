export function ProductDetails(props: any) {
  const { ProductInfo } = props;
  return (
    <>
      <div className="form-group">
        <label htmlFor="IdCtrl">ID</label>
        <p>{ProductInfo.id}</p>
      </div>
      <div className="form-group">
        <label htmlFor="NameCtrl">Name</label>
        <p>{ProductInfo.name}</p>
      </div>
      <div className="form-group">
        <label htmlFor="DescriptionCtrl">Description</label>
        <p>{ProductInfo.description}</p>
      </div>
      <div className="form-group">
        <label htmlFor="PriceCtrl">Price</label>
        <p>{ProductInfo.price}</p>
      </div>
    </>
  );
}

