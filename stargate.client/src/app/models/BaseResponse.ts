export class BaseResponse {
  success: boolean = false;
  message: string = "";
  responseCode: number | undefined; // HttpStatusCode.OK
}
